﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.DataModel.Data
{

    public interface IActivityRepository : IBaseRepository<Entities.Activity>
    {
        Task<IEnumerable<Entities.Activity>> GetListByTaskIdAsync(string taskId);
    }
}
