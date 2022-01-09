using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Team.Entities;

namespace TaskoMask.Domain.Team.Data
{
    public interface IInvitationRepository : IBaseRepository<Invitation>
    {
        Task<int> OrganizationsCountByInvitedMemberIdAsync(string invitedMemberId);
    }
}
