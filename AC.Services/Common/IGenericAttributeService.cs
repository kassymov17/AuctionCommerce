using System.Collections.Generic;
using AC.Core;
using AC.Core.Domain;
using AC.Core.Domain.Common;

namespace AC.Services.Common
{
    /// <summary>
    /// Интерфейс службы аттрибутов
    /// </summary>
    public partial interface IGenericAttributeService
    {
        void DeleteAttribute(GenericAttribute attribute);

        void DeleteAttributes(IList<GenericAttribute> attributes);

        GenericAttribute GetAttributeById(int attributeId);

        void InsertAttribute(GenericAttribute attribute);

        void UpdateAttribute(GenericAttribute attribute);
        
        IList<GenericAttribute> GetAttributesForEntity(int entityId, string keyGroup);

        void SaveAttribute<TPropType>(BaseEntity entity, string key, TPropType value);
    }
}
