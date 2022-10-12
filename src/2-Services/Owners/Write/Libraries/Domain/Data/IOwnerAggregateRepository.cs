using TaskoMask.BuildingBlocks.Domain.Data;
using TaskoMask.Services.Owners.Write.Domain.Entities;

namespace TaskoMask.Services.Owners.Write.Domain.Data
{
    public interface IOwnerAggregateRepository : IBaseAggregateRepository<Owner>
    {
        Task<Owner> GetByOrganizationIdAsync(string organizationId);
        Task<Owner> GetByProjectIdAsync(string projectId);
    }
}
