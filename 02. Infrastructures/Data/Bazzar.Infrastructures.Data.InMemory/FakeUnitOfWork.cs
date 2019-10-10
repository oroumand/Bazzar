using Framework.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Infrastructures.Data.InMemory
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public int Commit()
        {
            return 0;
        }
    }
}
