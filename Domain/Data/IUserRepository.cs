using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Domain.Data
{
    public interface IUserRepository
    {
        Task<long> CountAsync();
        Task<User> GetByIdAsync(string id);
    }
}
