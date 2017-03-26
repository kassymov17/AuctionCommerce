using System;
using System.Data.Entity.Core.Objects;
using AC.Core;

namespace AC.Data
{
    public static class Extensions
    {
        public static Type GetUnproxiedEntityType(this BaseEntity entity)
        {
            var userType = ObjectContext.GetObjectType(entity.GetType());
            return userType;
            ;
        }
    }
}
