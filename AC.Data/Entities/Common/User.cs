using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AC.Data.Entities.Common
{
    public class User
    {
        public virtual int UserId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Login { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Password { get; set; }
        public virtual int? Rating { get; set; }
    }
}
