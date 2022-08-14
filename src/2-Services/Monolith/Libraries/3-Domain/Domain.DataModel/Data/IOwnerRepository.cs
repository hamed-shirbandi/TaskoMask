using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Domain.Data;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;

namespace TaskoMask.Services.Monolith.Domain.DataModel.Data
{

    public interface IOwnerRepository : IBaseRepository<Owner>
    {
        IEnumerable<Owner> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount);
    }
}
