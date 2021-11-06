using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Services.Users.Dto;
using TaskoMask.Application.ViewMoldes.Account;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Services.Users
{
    public interface IUserService
    {
        Task<Result<CommandResult>> CreateAsync(RegisterViewModel input);
        Task<Result<CommandResult>> UpdateAsync(UserInput input);
        Task<UserOutput> GetByIdAsync(string id);
        Task<UserInput> GetByIdToUpdateAsync(string id);
        Task<long> CountAsync();
    }
}
