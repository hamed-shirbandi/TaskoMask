using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Common.Users;
using TaskoMask.Application.Core.Dtos.Team.Members;
using TaskoMask.Application.Core.Helpers;

namespace TaskoMask.Web.Common.Contracts
{
    public  interface IAccountWebService
    {
        Task<Result<string>> Login(UserLoginDto input);
        Task<Result<CommandResult>> Register(MemberRegisterDto input);
    }
}
