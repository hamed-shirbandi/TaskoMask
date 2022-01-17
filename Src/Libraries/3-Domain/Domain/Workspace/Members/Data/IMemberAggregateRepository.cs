using System.Collections.Generic;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Workspace.Members.Entities;

namespace TaskoMask.Domain.Workspace.Members.Data
{
    public interface IMemberAggregateRepository : IBaseAggregateRepository<Member>
    {
        IEnumerable<Member> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount);
    }
}
