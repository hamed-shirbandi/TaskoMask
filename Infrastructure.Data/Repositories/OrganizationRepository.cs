using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class OrganizationRepository : BaseRepository<Domain.Models.Organization>, IOrganizationRepository
    {

        private readonly IMongoCollection<Organization> _organizations;
        public OrganizationRepository(IMainDbContext dbContext) : base(dbContext)
        {
            _organizations = dbContext.GetCollection<Organization>(); ;
        }
      

        public async Task<IEnumerable<Organization>> GetListByUserIdAsync(string userId)
        {
            return await _organizations.AsQueryable().Where(o => o.UserId == userId).ToListAsync();
        }
    }
}
