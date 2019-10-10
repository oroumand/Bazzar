using System;

namespace Bazzar.Core.ApplicationServices.UserProfiles.Commands
{
    public class UpdateUserDisplayName
    {
        public Guid UserId { get; set; }
        public string DisplayName { get; set; }
    }
}
