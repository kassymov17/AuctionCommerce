using System;
using System.Linq;
using AC.Core;
using AC.Core.Infrastructure;
using AC.Data;

namespace AC.Services.Common
{
    public static class GenericAttributeExtensions
    {
        public static TPropType GetAttribute<TPropType>(this BaseEntity entity, string key)
        {
            var genericaAttributeService = EngineContext.Current.Resolve<IGenericAttributeService>();
            return GetAttribute<TPropType>(entity, key, genericaAttributeService);
        }

        public static TPropType GetAttribute<TPropType>(this BaseEntity entity, string key,
            IGenericAttributeService genericAttributeService)
        {
            if(entity == null)
                throw new ArgumentNullException("entity");

            string keyGroup = entity.GetUnproxiedEntityType().Name;

            var props = genericAttributeService.GetAttributesForEntity(entity.Id, keyGroup);

            if (props == null)
                return default(TPropType);

            props = props.ToList();
            if (!props.Any())
                return default(TPropType);

            var prop = props.FirstOrDefault(ga => ga.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase));

            if (prop == null || string.IsNullOrEmpty(prop.Value))
                return default(TPropType);

            return CommonHelper.To<TPropType>(prop.Value);
        }
    }
}
