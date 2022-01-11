using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;
using TaskoMask.Domain.Workspace.Members.Data;
using TaskoMask.Domain.Workspace.Members.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories.Workspace
{
    public class InvitationRepository : BaseRepository<Invitation>, IInvitationRepository
    {
        #region Fields

        private readonly IMongoCollection<Invitation> _invitations;

        #endregion

        #region Ctors

        public InvitationRepository(IMongoDbContext dbContext) : base(dbContext)
        {
            _invitations = dbContext.GetCollection<Invitation>();
        }





        #endregion

        #region Public Methods

        public async Task<int> OrganizationsCountByInvitedMemberIdAsync(string invitedMemberId)
        {
            return await _invitations.AsQueryable()
                .Where(i => i.InvitedMemberId == invitedMemberId)
                .Select(i => i.OrganizationId).Distinct().CountAsync();
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
