using System;

namespace Bazzar.Core.ApplicationServices.UserProfiles.Commands
{
    public class UpdateUserEmail
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
    }
}
