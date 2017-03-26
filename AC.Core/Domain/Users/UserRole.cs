using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC.Core.Domain.Users
{
    public partial class UserRole : BaseEntity
    {
        public string Name { get; set; }

        public bool Active { get; set; }

        public bool IsSystemRole { get; set; }

        public string SystemName { get; set; }
    }
}
