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
    public class CatalogController : Controller
    {
        #region Поля

        private readonly ICategoryService _categoryService;
        private readonly IItemService _itemService;
        private readonly IWorkContext _workContext;
        private readonly ITopicService _topicService;
        private readonly IPictureService _pictureService;
        private readonly ILocalizationService _localizationService;

        #endregion

        #region Конструктор

        public CatalogController(ICategoryService categoryService, IItemService itemService, IWorkContext workContext, ITopicService topicService, IPictureService pictureService, ILocalizationService localizationService)
        {
            _categoryService = categoryService;
            _itemService = itemService;
            _workContext = workContext;
            _topicService = topicService;
            _pictureService = pictureService;
            _localizationService = localizationService;
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

        #endregion

        #region Методы

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

        #endregion
    }
}