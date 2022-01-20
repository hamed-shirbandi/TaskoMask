using System.Collections.Generic;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Data
{
    public interface IOwnerAggregateRepository : IBaseRepository<Owner>
    {
        bool ExistOrganization(string ownerId,string organizationId, string organizationName);
        bool ExistProject(string ownerId, string organizationId, string projectName);
    }
}
