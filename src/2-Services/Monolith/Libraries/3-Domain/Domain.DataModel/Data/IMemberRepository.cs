using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Domain.Data;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;

namespace TaskoMask.Services.Monolith.Domain.DataModel.Data
{

    public interface IMemberRepository : IBaseRepository<Member>
    {
        Task<IEnumerable<Member>> GetListByBoardIdAsync(string boardId);
        Task<IEnumerable<Member>> GetListByOrganizationIdAsync(string organizationId);

    }
}
