using TaskoMask.BuildingBlocks.Domain.Data;
using TaskoMask.Services.Owners.Write.Domain.Entities;

namespace TaskoMask.Services.Owners.Write.Domain.Data
{
    public interface IOwnerAggregateRepository : IBaseAggregateRepository<Owner>
    {
        Task<Owner> GetByEmailAsync(string email);
        Task<Owner> GetByOrganizationIdAsync(string organizationId);
        Task<Owner> GetByProjectIdAsync(string projectId);
        bool ExistOwnerByEmail(string ownerId, string email);
    }
}
