using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.ViewMoldes.Account;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.BaseEntities.Services;

namespace TaskoMask.Application.Users.Services
{
    public interface IUserService 
    {
        #region Command Services

        Task<Result<CommandResult>> CreateAsync(RegisterViewModel input);
        Task<Result<CommandResult>> UpdateAsync(UserInput input);

        #endregion

        #region Query Services

        Task<UserOutput> GetByIdAsync(string id);
        Task<UserInput> GetByIdToUpdateAsync(string id);
        Task<long> CountAsync();

        #endregion


    }
}
