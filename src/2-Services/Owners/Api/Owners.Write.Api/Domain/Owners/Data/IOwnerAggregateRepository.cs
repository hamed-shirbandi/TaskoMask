using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Services;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Entities;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Data;

public interface IOwnerAggregateRepository : IBaseAggregateRepository<Owner>
{
    Task<Owner> GetByEmailAsync(string email);
    Task<Owner> GetByOrganizationIdAsync(string organizationId);
    Task<Owner> GetByProjectIdAsync(string projectId);
    bool ExistOwnerByEmail(string ownerId, string email);
}
