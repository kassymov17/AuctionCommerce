using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AC.Core;
using AC.Core.Domain.Catalog;
using AC.Services.Catalog;
using AC.Services.Localization;
using AC.Services.Media;
using AC.Services.Topics;
using AC.Web.Extensions;
using AC.Web.Models.Catalog;
using AC.Web.Models.Media;

namespace AC.Web.Controllers
{
    public class CatalogController : BasePublicController
    {
        #region Поля

        private readonly ICategoryService _categoryService;
        private readonly IItemService _itemService;
        private readonly IWorkContext _workContext;
        private readonly ITopicService _topicService;
        private readonly IPictureService _pictureService;
        private readonly ILocalizationService _localizationService;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Конструктор

        public CatalogController(IWebHelper webHelper, ICategoryService categoryService, IItemService itemService, IWorkContext workContext, ITopicService topicService, IPictureService pictureService, ILocalizationService localizationService)
        {
            _categoryService = categoryService;
            _itemService = itemService;
            _workContext = workContext;
            _topicService = topicService;
            _pictureService = pictureService;
            _localizationService = localizationService;
            _webHelper = webHelper;
        }

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Подготовка модели категорий
        /// </summary>
        /// <param name="rootCategoryId">Ид корневой категории</param>
        /// <param name="loadSubCategories">Параметр указывающий грузить ли подкатегории</param>
        /// <param name="allCategories">Все категоии доступны</param>
        /// <returns></returns>
        [NonAction]
        protected virtual IList<CategorySimpleModel> PrepareCategorySimpleModels(int rootCategoryId,
            bool loadSubCategories = true, IList<Category> allCategories = null)
        {
            var result = new List<CategorySimpleModel>();

            if (allCategories == null)
            {
                allCategories = _categoryService.GetAllCategories();
            }
            var categories = allCategories.Where(c => c.ParentCategoryId == rootCategoryId).ToList();
            foreach (var category in categories)
            {
                var categoryModel = new CategorySimpleModel
                {
                    Id = category.Id,
                    Name = category.Name, // [todo] заюзать локализацию
                    SeName = "SeName", // [todo] получить seo 
                    IncludeInTopMenu = category.IncludeInTopMenu
                };

                // количество вещей в каждой категории категории 
                var categoryIds = new List<int>();
                categoryIds.Add(category.Id);
                // включая подкатегории
                categoryIds.AddRange(GetChildCategoryIds(category.Id));
                categoryModel.NumberOfProducts = _itemService.GetNumberOfItemsInCategory(categoryIds);

                if (loadSubCategories)
                {
                    var subCategories = PrepareCategorySimpleModels(category.Id, loadSubCategories, allCategories);
                    categoryModel.SubCategories.AddRange(subCategories);
                }
                result.Add(categoryModel);
            }

            return result;
        }

        [NonAction]
        protected virtual List<int> GetChildCategoryIds(int parentCategoryId)
        {
            var categoriesIds = new List<int>();
            var categories = _categoryService.GetAllCategoriesByParentCategoryId(parentCategoryId);
            foreach (var category in categories)
            {
                categoriesIds.Add(category.Id);
                categoriesIds.AddRange(GetChildCategoryIds(category.Id));
            }
            return categoriesIds;
        }

        [NonAction]
        protected virtual void PrepareSortingOptions(CatalogPagingFilteringModel pagingFilteringModel, CatalogPagingFilteringModel command)
        {
            if(pagingFilteringModel == null)
                throw new ArgumentNullException("pagingFilteringModel");

            if(command == null)
                throw new ArgumentNullException("command");

            pagingFilteringModel.AllowItemSorting = true;

            var activeOptions = Enum.GetValues(typeof(ItemSortingEnum)).Cast<int>()
                .Select((idOption) =>
                {
                    int order;
                    return new KeyValuePair<int, int>(idOption, idOption);
                })
                .OrderBy(x => x.Value);

            if (command.OrderBy == null)
                command.OrderBy = activeOptions.First().Key;

            if (pagingFilteringModel.AllowItemSorting)
            {
                foreach (var option in activeOptions)
                {
                    var currentPageUrl = _webHelper.GetThisPageUrl(true);
                    var sortUrl = _webHelper.ModifyQueryString(currentPageUrl, "orderby=" + (option.Key).ToString(), null);

                    var sortValue = ((ItemSortingEnum) option.Key).ToString();
                    pagingFilteringModel.AvailableSortOptions.Add(new SelectListItem
                    {
                        Text = sortValue,
                        Value = sortUrl,
                        Selected = option.Key == command.OrderBy
                    });
                }
            }

        }

        [NonAction]
        protected virtual void PreparePageSizeOptions(CatalogPagingFilteringModel pagingFilteringModel , CatalogPagingFilteringModel command , string pageSizeOptions , int fixedPageSize )
        {
            if(pagingFilteringModel == null)
                throw new ArgumentNullException("pagingFilteringModel");

            if(command == null)
                throw new ArgumentNullException("command");

            if (command.PageNumber <= 0)
                command.PageNumber = 1;

            pagingFilteringModel.AllowUsersToSelectPageSize = false;
            if (pageSizeOptions != null)
            {
                var pageSizes = pageSizeOptions.Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);

                if (pageSizes.Any())
                {
                    if (command.PageSize <= 0 || !pageSizes.Contains(command.PageSize.ToString()))
                    {
                        int temp;
                        if (int.TryParse(pageSizes.FirstOrDefault(), out temp))
                        {
                            if (temp > 0)
                            {
                                command.PageSize = temp;
                            }
                        }
                    }

                    var currentPageUrl = _webHelper.GetThisPageUrl(true);
                    var sortUrl = _webHelper.ModifyQueryString(currentPageUrl, "pageSize={0}", null);
                    sortUrl = _webHelper.RemoveQueryString(sortUrl, "pageNumber");

                    foreach (var pageSize in pageSizes)
                    {
                        int temp;
                        if (!int.TryParse(pageSize, out temp))
                        {
                            continue;
                        }
                        if (temp <= 0)
                        {
                            continue;
                        }

                        pagingFilteringModel.PageSizeOptions.Add(new SelectListItem
                        {
                            Text = pageSize,
                            Value = String.Format(sortUrl, pageSize),
                            Selected =
                                pageSize.Equals(command.PageSize.ToString(), StringComparison.InvariantCultureIgnoreCase)
                        });
                    }
                    if (pagingFilteringModel.PageSizeOptions.Any())
                    {
                        pagingFilteringModel.PageSizeOptions = pagingFilteringModel.PageSizeOptions.OrderBy(x => int.Parse(x.Text)).ToList();
                        pagingFilteringModel.AllowUsersToSelectPageSize = true;

                        if (command.PageSize <= 0)
                        {
                            command.PageSize = int.Parse(pagingFilteringModel.PageSizeOptions.FirstOrDefault().Text);
                        }
                    }
                }
            }
            else
            {
                command.PageSize = fixedPageSize;
            }

            if (command.PageSize <= 0)
            {
                command.PageSize = fixedPageSize;
            }
        }

        [NonAction]
        protected virtual IEnumerable<ItemOverviewModel> PrepareItemOverviewModels(IEnumerable<Item> items)
        {
            return this.PrepareItemOverviewModels(_workContext, _categoryService, _itemService, _localizationService,
                _pictureService, items);
        }

        #endregion

        #region Методы

        public ActionResult Category(int categoryId, CatalogPagingFilteringModel command)
        {
            var category = _categoryService.GetCategoryById(categoryId);
            if (category == null || category.Deleted)
                return InvokeHttp404();


            var model = category.ToModel();

            // сортировка
            PrepareSortingOptions(model.PagingFilteringContext, command);

            // размеры страницы
            PreparePageSizeOptions(model.PagingFilteringContext, command, category.PageSizeOptions, category.PageSize);
            
            // хлебные крошки категорий
            model.DisplayCategoryBreadcrumb = true;
            model.CategoryBreadcrumb = category.GetCategoryBreadCrumb(_categoryService)
                .Select(catBr => new CategoryModel
                {
                    Id = catBr.Id,
                    Name = catBr.Name,
                    SeName = "SeName"
                }).ToList();

            var pictureSize = 450;
            
            // подкатегории
            var categories = _categoryService.GetAllCategoriesByParentCategoryId(categoryId)
                .Select(x =>
                {
                    var subCatModel = new CategoryModel.SubCategoryModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description
                    };

                    var picture = _pictureService.GetPictureById(x.PictureId);
                    var pictureModel = new PictureModel
                    {
                        FullSizeImgUrl = _pictureService.GetPictureUrl(picture),
                        ImageUrl = _pictureService.GetPictureUrl(picture, pictureSize),
                        Title = subCatModel.Name,
                        AlternateText = subCatModel.Name
                    };

                    subCatModel.PictureModel = pictureModel;

                    return subCatModel;
                }).ToList();
            model.SubCategories = categories;

            // избранные товары

            var categoryIds = new List<int>();
            categoryIds.Add(category.Id);
            categoryIds.AddRange(GetChildCategoryIds(category.Id));

            var items = _itemService.SearchItems(
                categoryIds: categoryIds,
                orderBy: (ItemSortingEnum)command.OrderBy,
                pageIndex: command.PageNumber - 1,
                pageSize: command.PageSize
                );
            model.Items = PrepareItemOverviewModels(items).ToList();
            model.PagingFilteringContext.LoadPagedList(items);

            return View(model);
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            // категории
            var categoriesModel = PrepareCategorySimpleModels(0);

            // top menu topics
            var topicModel = _topicService.GetAllTopics()
                .Where(t => t.IncludedInTopMenu)
                .Select(t => new TopMenuModel.TopMenuTopicModel
                {
                    Id = t.Id,
                    Name = t.Title,
                    SeName = "SeName"
                })
                .ToList();

            var model = new TopMenuModel
            {
                Categories =  categoriesModel,
                Topics = topicModel
            };

            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult HomepageCategories()
        {
            var pictureSize = 450;
            var categories = _categoryService.GetAllCategoriesDisplayedOnHomePage()
                .Select(x =>
                {
                    var catModel = x.ToModel();
                    // подготовить модель изображения
                    //var picture = _pictureService.GetPictureById(x.PictureId);
                    catModel.PictureModel = new PictureModel
                    {
                        FullSizeImgUrl = _pictureService.GetPictureUrl(_pictureService.GetPictureById(x.PictureId)),
                        ImageUrl = _pictureService.GetPictureUrl(_pictureService.GetPictureById(x.PictureId), pictureSize),
                        Title = string.Format(_localizationService.GetResource("Media.Category.ImageLinkTitleCategory"), catModel.Name),
                        AlternateText = string.Format(_localizationService.GetResource("Media.Category.ImageAlternateTextFormat"), catModel.Name)
                    };
                    return catModel;
                }).ToList();

            if (!categories.Any())
                return Content("");

            return PartialView(categories);
        }

        [ChildActionOnly]
        public ActionResult CategoryNavigation(int currentCategoryId, int currentItemId)
        {
            int activeCategoryId = 0;
            if (currentCategoryId > 0)
            {
                activeCategoryId = currentCategoryId;
            } 
            else if (currentItemId > 0)
            {
                var itemCategories = _categoryService.GetItemCategoriesByItemId(currentItemId);
                if (itemCategories.Any())
                    activeCategoryId = itemCategories[0].CategoryId;
            }

            var categoryModels = PrepareCategorySimpleModels(0).ToList();

            var model = new CategoryNavigationModel
            {
                CurrentCategoryId = activeCategoryId,
                Categories = categoryModels
            };

            return PartialView(model);
        }

        #endregion
    }
}