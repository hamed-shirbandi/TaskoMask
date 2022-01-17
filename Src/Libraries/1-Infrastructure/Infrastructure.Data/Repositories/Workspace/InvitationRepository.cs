using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;
using TaskoMask.Domain.Workspace.Owners.Data;
using TaskoMask.Domain.Workspace.Owners.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories.Workspace
{
    public class InvitationRepository : BaseAggregateRepository<Invitation>, IInvitationRepository
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

        public async Task<int> OrganizationsCountByInvitedOwnerIdAsync(string invitedOwnerId)
        {
            return await _invitations.AsQueryable()
                .Where(i => i.InvitedOwnerId == invitedOwnerId)
                .Select(i => i.OrganizationId).Distinct().CountAsync();
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
