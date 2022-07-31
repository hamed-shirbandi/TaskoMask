using System.Collections.Generic;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.DataModel.Entities;

namespace TaskoMask.Domain.DataModel.Data
{

    public interface IOwnerRepository : IBaseRepository<Owner>
    {
        IEnumerable<Owner> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount);
    }
}
