using Framework.Domain.Data;

namespace Bazzar.Infrastructures.Data.SqlServer
{
    public class AdvertismentUnitOfWork : IUnitOfWork
    {
        private readonly AdvertismentDbContext advertismentDbContext;

        public AdvertismentUnitOfWork(AdvertismentDbContext advertismentDbContext)
        {
            this.advertismentDbContext = advertismentDbContext;
        }
        public int Commit()
        {
            return advertismentDbContext.SaveChanges();
        }
    }
}
