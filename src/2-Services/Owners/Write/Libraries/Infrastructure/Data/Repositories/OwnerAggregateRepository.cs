using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Owners.Write.Domain.Data;
using TaskoMask.Services.Owners.Write.Domain.Entities;
using TaskoMask.Services.Owners.Write.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Owners.Write.Infrastructure.Data.Repositories
{
    public class OwnerAggregateRepository : MongoDbBaseAggregateRepository<Owner>, IOwnerAggregateRepository
    {
        #region Fields

        protected readonly IMongoCollection<Owner> _owners;


        #endregion

        #region Ctors

        public OwnerAggregateRepository(OwnerWriteDbContext dbContext) : base(dbContext)
        {
            _owners = dbContext.Owners;

        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Owner> GetByEmailAsync(string email)
        {
            return await _owners.Find(o => o.Email.Value == email).FirstOrDefaultAsync();

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Owner> GetByOrganizationIdAsync(string organizationId)
        {
            return await _owners.Find(o => o.Organizations.Any(c => c.Id == organizationId)).FirstOrDefaultAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Owner> GetByProjectIdAsync(string projectId)
        {
            return await _owners.Find(o => o.Organizations.Any(c => c.Projects.Any(p => p.Id == projectId))).FirstOrDefaultAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public bool ExistOwnerByEmail(string ownerId, string email)
        {
            return _owners.AsQueryable().Any(o => o.Id != ownerId && o.Email.Value == email);
        }


        #endregion

        #region Private Methods



        #endregion

    }
}
