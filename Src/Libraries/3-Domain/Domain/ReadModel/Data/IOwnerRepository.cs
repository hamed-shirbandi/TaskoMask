using System.Collections.Generic;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.ReadModel.Entities;

namespace TaskoMask.Domain.ReadModel.Data
{

    public interface IOwnerRepository : IBaseRepository<Owner>
    {
        IEnumerable<Owner> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount);
    }
}
