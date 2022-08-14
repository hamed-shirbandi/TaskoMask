using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Data
{
    public interface IOwnerAggregateRepository : IBaseAggregateRepository<Owner>
    {
        Task<Owner> GetByOrganizationIdAsync(string organizationId);
        Task<Owner> GetByProjectIdAsync(string projectId);
    }
}
