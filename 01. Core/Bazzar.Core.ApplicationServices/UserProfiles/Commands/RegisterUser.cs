using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.ApplicationServices.UserProfiles.Commands
{
    public class RegisterUser
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }
}
