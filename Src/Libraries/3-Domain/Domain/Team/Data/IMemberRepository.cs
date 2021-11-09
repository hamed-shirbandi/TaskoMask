using System.Collections.Generic;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Team.Entities;

namespace TaskoMask.Domain.Team.Data
{
    public interface IMemberRepository : IUserRepository<Member>
    {
        IEnumerable<Member> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount);
    }
}
