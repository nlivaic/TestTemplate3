using System.Threading.Tasks;
using TestTemplate3.Common.Interfaces;

namespace TestTemplate3.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestTemplate3DbContext _dbContext;

        public UnitOfWork(TestTemplate3DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveAsync()
        {
            if (_dbContext.ChangeTracker.HasChanges())
            {
                return await _dbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}