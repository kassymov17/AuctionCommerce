using System.Collections.Generic;
using System.Linq;

namespace AC.Services.Users
{
    public class UserRegistrationResult
    {
        public UserRegistrationResult()
        {
            this.Errors = new List<string>();
        }

        public bool Success
        {
            get { return !this.Errors.Any(); }
        }

        public void AddError(string error)
        {
            this.Errors.Add(error);
        }

        public IList<string> Errors { get; set; }
    }
}
