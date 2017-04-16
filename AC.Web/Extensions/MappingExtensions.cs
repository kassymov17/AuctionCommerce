using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AC.Core.Domain.Catalog;
using AC.Web.Models.Catalog;

namespace AC.Web.Extensions
{
    public static class MappingExtensions
    {
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
    }
}