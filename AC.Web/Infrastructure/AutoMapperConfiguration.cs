using AC.Core.Domain.Catalog;
using AC.Web.Models.Catalog;
using AutoMapper;

namespace AC.Web.Infrastructure
{
    public static class AutoMapperConfiguration
    {
        private static MapperConfiguration _mapperConfiguration;
        private static IMapper _mapper;

        public static void Init()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItemModel, Item>()
                    .ForMember(dest => dest.CreatedOnUtc, mo => mo.Ignore())
                    .ForMember(dest => dest.UpdatedOnUtc, mo => mo.Ignore())
                    .ForMember(dest => dest.ItemType, mo => mo.Ignore())
                    .ForMember(dest => dest.Deleted, mo => mo.Ignore())
                    .ForMember(dest => dest.ApprovedRatingSum, mo => mo.Ignore())
                    .ForMember(dest => dest.NotApprovedRatingSum, mo => mo.Ignore())
                    .ForMember(dest => dest.ApprovedTotalReviews, mo => mo.Ignore())
                    .ForMember(dest => dest.NotApprovedTotalReviews, mo => mo.Ignore())
                    .ForMember(dest => dest.ItemCategories, mo => mo.Ignore())
                    .ForMember(dest => dest.ItemPictures, mo => mo.Ignore());

                // items
                cfg.CreateMap<Item, ItemModel>()
                    .ForMember(dest => dest.ItemTypeName, mo => mo.Ignore())
                    .ForMember(dest => dest.StockQuantityStr, mo => mo.Ignore())
                    .ForMember(dest => dest.CreatedOn, mo => mo.Ignore())
                    .ForMember(dest => dest.UpdatedOn, mo => mo.Ignore())
                    .ForMember(dest => dest.PictureThumbnailUrl, mo => mo.Ignore())
                    .ForMember(dest => dest.AvailableCategories, mo => mo.Ignore())
                    .ForMember(dest => dest.AddPictureModel, mo => mo.Ignore())
                    .ForMember(dest => dest.ItemPictureModels, mo => mo.Ignore())
                    .ForMember(dest => dest.SelectedCategoryIds, mo => mo.Ignore())
                    .ForMember(dest => dest.LastStockQuantity, mo => mo.Ignore());
            });
            _mapper = _mapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Mapper
        /// </summary>
        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }
        /// <summary>
        /// Mapper configuration
        /// </summary>
        public static MapperConfiguration MapperConfiguration
        {
            get
            {
                return _mapperConfiguration;
            }
        }
    }
}