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
        public OrganizationRepository(IMainDbContext dbContext) : base(dbContext)
        {

        }
        public Task<IEnumerable<Organization>> GetListByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
