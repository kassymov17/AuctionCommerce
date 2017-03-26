using System;
using System.Collections.Generic;
using System.Linq;
using AC.Core;
using AC.Core.Data;
using AC.Core.Domain.Common;
using AC.Data;
using AC.Data.Abstract;

namespace AC.Services.Common
{
    public partial class GenericAttributeService : IGenericAttributeService
    {
        #region Поля

        private readonly IRepository<GenericAttribute> _genericAttributeRepository;

        #endregion

        #region Конструктор

        public GenericAttributeService(IRepository<GenericAttribute> genericAttributeRepository)
        {
            _genericAttributeRepository = genericAttributeRepository;
        }

        #endregion

        #region Методы

        public virtual void DeleteAttribute(GenericAttribute attribute)
        {
            if(attribute == null)
                throw new ArgumentNullException("attribute");

            _genericAttributeRepository.Delete(attribute);
        }

        public virtual void DeleteAttributes(IList<GenericAttribute> attributes)
        {
            if (attributes == null)
                throw new ArgumentNullException("attributes");

            _genericAttributeRepository.Delete(attributes);
        }

        public virtual GenericAttribute GetAttributeById(int attributeId)
        {
            if (attributeId == 0)
                return null;

            return _genericAttributeRepository.GetById(attributeId);
        }

        public virtual void InsertAttribute(GenericAttribute attribute)
        {
            if (attribute == null)
                throw new ArgumentNullException("attribute");

            _genericAttributeRepository.Insert(attribute);
        }

        public virtual void UpdateAttribute(GenericAttribute attribute)
        {
            if (attribute == null)
                throw new ArgumentNullException("attribute");

            _genericAttributeRepository.Update(attribute);
        }

        public virtual IList<GenericAttribute> GetAttributesForEntity(int entityId, string keyGroup)
        {
            var query = from ga in _genericAttributeRepository.Table
                where ga.EntityId == entityId &&
                      ga.KeyGroup == keyGroup
                select ga;
            var attributes = query.ToList();

            return attributes;
        }

        public virtual void SaveAttribute<TPropType>(BaseEntity entity, string key, TPropType value)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            if (key == null)
                throw new ArgumentNullException("key");

            string keyGroup = entity.GetUnproxiedEntityType().Name;

            var props = GetAttributesForEntity(entity.Id, keyGroup)
                .ToList();
            var prop = props.FirstOrDefault(ga =>
                ga.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)); //should be culture invariant

            var valueStr = CommonHelper.To<string>(value);

            if (prop != null)
            {
                if (string.IsNullOrWhiteSpace(valueStr))
                {
                    //delete
                    DeleteAttribute(prop);
                }
                else
                {
                    //update
                    prop.Value = valueStr;
                    UpdateAttribute(prop);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(valueStr))
                {
                    //insert
                    prop = new GenericAttribute
                    {
                        EntityId = entity.Id,
                        Key = key,
                        KeyGroup = keyGroup,
                        Value = valueStr,
                    };
                    InsertAttribute(prop);
                }
            }
        }

        #endregion
    }
}
