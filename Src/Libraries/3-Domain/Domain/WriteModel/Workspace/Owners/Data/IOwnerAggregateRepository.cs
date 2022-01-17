using System.Collections.Generic;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Workspace.Owners.Entities;

namespace TaskoMask.Domain.Workspace.Owners.Data
{
    public interface IOwnerAggregateRepository : IBaseAggregateRepository<Owner>
    {
        IEnumerable<Owner> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount);
    }
}
