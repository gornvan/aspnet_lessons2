using lesson11_FabricMarket_DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FabricMarket_DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public TEntity Create(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }

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

        public async Task<TEntity> InsertOrUpdate(
            Expression<Func<TEntity, bool>> predicate,
            TEntity entity
        ){
            var entityExists = await _dbSet.AnyAsync(predicate);
            if (entityExists)
            {
                return _dbSet.Update(entity).Entity;
            }
            
            return _dbSet.Add(entity).Entity;
        }
    }
}
