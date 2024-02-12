
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FabricMarket_DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        private IDbContextTransaction _currentTransaction;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            lock (_context) {
                if (_currentTransaction != null)
                {
                    throw new UnitOfWorkAlreadyInTransactionStateException();
                }

                _currentTransaction = _context.Database.BeginTransaction();
            }
            return _currentTransaction;
        }

        IRepository<TEntity> IUnitOfWork.GetRepository<TEntity>()
        {
            return new Repository<TEntity>(_context);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
