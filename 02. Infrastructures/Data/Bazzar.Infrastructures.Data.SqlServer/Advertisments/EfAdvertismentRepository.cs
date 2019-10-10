using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.Entities;
using System;
using System.Linq;

namespace Bazzar.Infrastructures.Data.SqlServer.Advertisments
{
    public class EfAdvertismentRepository : IAdvertisementsRepository, IDisposable
    {
        private readonly AdvertismentDbContext advertismentDbContext;

        public EfAdvertismentRepository(AdvertismentDbContext advertismentDbContext)
        {
            this.advertismentDbContext = advertismentDbContext;
        }
        public  void Add(Advertisment entity)
        {
            advertismentDbContext.Advertisments.Add(entity);
        }

        public bool Exists(Guid id)
        {
            return   advertismentDbContext.Advertisments.Any(c => c.Id == id);
        }

        public Advertisment Load(Guid id)
        {
            return  advertismentDbContext.Advertisments.Find(id);
        }
       
        public void Dispose()
        {
            advertismentDbContext.Dispose();
        }
    }
}
