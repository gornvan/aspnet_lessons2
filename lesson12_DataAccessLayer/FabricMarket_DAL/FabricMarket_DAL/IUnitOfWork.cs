using lesson11_FabricMarket_DomainModel.Models;
using System.Data.Entity;

namespace FabricMarket_DAL
{
    public interface IUnitOfWork
    {
        DbContextTransaction BeginTransaction();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;

        Task<int> SaveChangesAsync();
    }
}
