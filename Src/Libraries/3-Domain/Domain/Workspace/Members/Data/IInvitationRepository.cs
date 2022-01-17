using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Workspace.Members.Entities;

namespace TaskoMask.Domain.Workspace.Members.Data
{
    public interface IInvitationRepository : IBaseAggregateRepository<Invitation>
    {
        Task<int> OrganizationsCountByInvitedMemberIdAsync(string invitedMemberId);
    }
}
