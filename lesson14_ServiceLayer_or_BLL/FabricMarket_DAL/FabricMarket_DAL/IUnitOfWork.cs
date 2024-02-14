using FabricMarket_DAL.Repository;
using lesson11_FabricMarket_DomainModel.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace FabricMarket_DAL
{
    public interface IUnitOfWork
    {
        IDbContextTransaction BeginTransaction();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;

        Task<int> SaveChangesAsync();
    }
}
