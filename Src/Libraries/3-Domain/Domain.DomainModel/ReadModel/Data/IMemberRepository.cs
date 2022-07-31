using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.ReadModel.Entities;

namespace TaskoMask.Domain.ReadModel.Data
{

    public interface IMemberRepository : IBaseRepository<Member>
    {
        Task<IEnumerable<Member>> GetListByBoardIdAsync(string boardId);
        Task<IEnumerable<Member>> GetListByOrganizationIdAsync(string organizationId);

    }
}
