using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AC.Core.Domain.Users;

namespace AC.Services.Authentication
{
    public partial class FormsAuthenticationService : IAuthenticationService
    {
        public virtual User GetAuthenticatedUser()
        {
            // [todo] реализовать аутентификацию
            return null;
        }
    }
}
