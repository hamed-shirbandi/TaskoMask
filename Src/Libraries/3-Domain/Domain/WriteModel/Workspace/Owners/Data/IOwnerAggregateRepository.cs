using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Data
{
    public interface IOwnerAggregateRepository : IBaseAggregateRepository<Owner>
    {
        Task<Owner> GetByOrganizationIdAsync(string organizationId);
        Task<Owner> GetByProjectIdAsync(string projectId);
    }
}
