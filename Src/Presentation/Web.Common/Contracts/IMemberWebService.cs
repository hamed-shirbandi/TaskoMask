using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Team.Members;
using TaskoMask.Application.Core.Helpers;

namespace TaskoMask.Web.Common.Contracts
{
    public interface IMemberWebService
    {
        Task<Result<CommandResult>> Add(string email);
        Task<Result<CommandResult>> Delete(string id);
        Task<Result<MemberBasicInfoDto>> Get(string id);
        Task<Result<CommandResult>> Update();
    }
}
