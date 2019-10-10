using System;

namespace Bazzar.Core.ApplicationServices.UserProfiles.Commands
{
    public class UpdateUserName
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
