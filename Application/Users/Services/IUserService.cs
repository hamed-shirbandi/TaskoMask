using TaskoMask.Domain.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Users;
using TaskoMask.Application.Core.ViewMoldes.Account;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Application.Core.Services;

namespace TaskoMask.Application.Users.Services
{
    public interface IUserService : IBaseApplicationService
    {
        Task<Result<CommandResult>> CreateAsync(UserInputDto input);
        Task<Result<CommandResult>> UpdateAsync(UserInputDto input);
        Task<Result<UserBasicInfoDto>> GetAsync(string id);
        Task<Result<long>> CountAsync();

    }
}
