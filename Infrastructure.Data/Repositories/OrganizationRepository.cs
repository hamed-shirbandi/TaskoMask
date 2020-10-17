using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class OrganizationRepository : Repository<Domain.Models.Organization>, IOrganizationRepository
    {
        public OrganizationRepository()
        {

        }
        public Task<IEnumerable<Organization>> GetListByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
