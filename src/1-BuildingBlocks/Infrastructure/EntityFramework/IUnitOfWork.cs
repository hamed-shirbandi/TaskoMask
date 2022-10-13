using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Models;

namespace TaskoMask.BuildingBlocks.Infrastructure.EntityFramework
{
    public interface IUnitOfWork: IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void MarkAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity;
        void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
