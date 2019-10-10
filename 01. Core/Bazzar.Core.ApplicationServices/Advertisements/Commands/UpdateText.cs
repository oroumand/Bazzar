using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.ApplicationServices.Advertisements.Commands
{
    public class UpdateText
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}
