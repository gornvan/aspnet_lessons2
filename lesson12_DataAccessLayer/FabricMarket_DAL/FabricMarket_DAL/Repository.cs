using lesson11_FabricMarket_DomainModel.Models;
using System.Data.Entity;

namespace FabricMarket_DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context){
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<TEntity> AsReadOnlyQueryable()
        {
            return _dbSet.AsQueryable().AsNoTracking();
        }

        public TEntity Create(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            return _dbSet.Remove(entity);
        }
    }
}
