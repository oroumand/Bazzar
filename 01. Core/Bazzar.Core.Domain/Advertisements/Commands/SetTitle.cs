using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.Commands
{
    public class SetTitle
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
