using lesson11_FabricMarket_DomainModel.Models;
using Microsoft.EntityFrameworkCore;

namespace FabricMarket_DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context){
            _dbSet = context.Set<TEntity>();
        }

        public TEntity Create(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        // insert or update to be added

        public TEntity Delete(TEntity entity)
        {
            return _dbSet.Remove(entity).Entity;
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<TEntity> AsReadOnlyQueryable()
        {
            return _dbSet.AsQueryable().AsNoTracking();
        }
    }
}
