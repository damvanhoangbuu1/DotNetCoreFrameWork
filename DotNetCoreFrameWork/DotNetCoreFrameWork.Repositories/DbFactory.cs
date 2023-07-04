using DotNetCoreFrameWork.Entities.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreFrameWork.Repositories
{
    public class DbFactory : IDisposable
    {
        private bool _disposed;
        private Func<AudioTruyenContext> _instanceFunc;
        private DbContext _dbContext;
        public DbContext DbContext => _dbContext ?? (_dbContext = _instanceFunc.Invoke());

        public DbFactory(Func<AudioTruyenContext> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }

        public void Dispose()
        {
            if (!_disposed && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();
            }
        }
    }
}
