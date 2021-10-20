using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Team.Data;
using TaskoMask.Domain.Team.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        #region Fields

        private readonly IMongoCollection<Organization> _organizations;

        #endregion

        #region Ctors

        public OrganizationRepository(IMongoDbContext dbContext) : base(dbContext)
        {
            _organizations = dbContext.GetCollection<Organization>();
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> ExistByNameAsync(string id, string name)
        {
            var organization = await _organizations.Find(e => e.Name == name).FirstOrDefaultAsync();
            return organization != null && organization.Id != id;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Organization>> GetListByOwnerMemberIdAsync(string ownerMemberId)
        {
            return await _organizations.AsQueryable().Where(o => o.OwnerMemberId == ownerMemberId).ToListAsync();
        }

        #endregion

        #region Private Methods



        #endregion





    }
}
