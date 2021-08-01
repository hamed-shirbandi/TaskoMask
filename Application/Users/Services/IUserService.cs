using TaskoMask.Application.Core.Helpers;
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
        Task<Result<CommandResult>> UpdateAsync(UserInputDto input);

        #endregion

        #region Query Services

        Task<UserBasicInfoDto> GetByIdAsync(string id);
        Task<UserInputDto> GetByIdToUpdateAsync(string id);
        Task<long> CountAsync();

        #endregion


    }
}
