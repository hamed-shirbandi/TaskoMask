using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.Data
{
    public interface IOrganizationRepository : IBaseRepository<Models.Organization>
    {
        Task<IEnumerable<Models.Organization>> GetListByUserIdAsync(string userId);
    }
}
