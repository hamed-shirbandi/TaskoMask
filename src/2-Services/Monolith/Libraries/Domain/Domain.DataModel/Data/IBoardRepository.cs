﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.DataModel.Entities;

namespace TaskoMask.Domain.DataModel.Data
{

    public interface IBoardRepository : IBaseRepository<Board>
    {
        Task<IEnumerable<Board>> GetListByProjectIdAsync(string projectId);
        Task<IEnumerable<Board>> GetListByOrganizationIdAsync(string organizationId);
        IEnumerable<Board> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount);
        Task<long> CountByProjectIdAsync(string projectId);
        Task<IEnumerable<Board>> GetListByProjectsIdAsync(string[] projectsId);
        Task<long> CountByProjectsIdAsync(string[] projectsId);
    }
}
