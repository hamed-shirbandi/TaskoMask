using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Workspace.Owners.Entities;

namespace TaskoMask.Domain.Workspace.Owners.Data
{
    public interface IInvitationRepository : IBaseAggregateRepository<Invitation>
    {
        Task<int> OrganizationsCountByInvitedOwnerIdAsync(string invitedOwnerId);
    }
}
