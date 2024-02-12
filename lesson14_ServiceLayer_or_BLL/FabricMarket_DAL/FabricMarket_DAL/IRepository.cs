using lesson11_FabricMarket_DomainModel.Models;

namespace FabricMarket_DAL
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity Create(TEntity entity);

        // insert or update to be added

        /// <summary>
        /// The entity must be FOUND in the DB first
        /// </summary>
        TEntity Delete(TEntity entity);

        /// <summary>
        /// Query for Updatable (Tracked) entities
        /// </summary>
        IQueryable<TEntity> AsQueryable();

        /// <summary>
        /// Query for read-only (Untracked) entities
        /// </summary>
        IQueryable<TEntity> AsReadOnlyQueryable();
    }
}
