using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.Commands
{
    public class UpdatePrice
    {
        public Guid Id { get; set; }
        public long Price { get; set; }
    }
}
