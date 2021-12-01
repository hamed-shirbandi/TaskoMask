using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Dtos.Common.Users;
using TaskoMask.Application.Core.Dtos.Team.Members;
using TaskoMask.Application.Core.Helpers;
using TaskoMask.Web.Common.Contracts;

namespace TaskoMask.Web.Panel.Data
{
    public class AccountWebService : IAccountWebService
    {
        public AccountWebService()
        {

        }
        public Task<Result<string>> Login(UserLoginDto input)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CommandResult>> Register(MemberRegisterDto input)
        {
            throw new NotImplementedException();
        }
    }
}
