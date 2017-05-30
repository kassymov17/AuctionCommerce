using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AC.Core.Domain.Catalog;
using AC.Web.Infrastructure;
using AC.Web.Models.Catalog;

namespace AC.Web.Extensions
{
    public static class MappingExtensions
    {
        // мапперы
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        // категория
        public static CategoryModel ToModel(this Category entity)
        {
            if (entity == null)
                return null;

            var model = new CategoryModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                MetaDescription = entity.MetaDescription,
                MetaKeywords = entity.MetaKeywords,
                MetaTitle = entity.MetaTitle
            };

            return model;
        }

        public static ItemModel ToModel(this Item entity)
        {
            return entity.MapTo<Item, ItemModel>();
        }

        public static Item ToEntity(this ItemModel model)
        {
            return model.MapTo<ItemModel, Item>();
        }
    }
}