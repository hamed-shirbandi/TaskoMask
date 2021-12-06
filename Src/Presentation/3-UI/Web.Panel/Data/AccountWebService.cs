using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Application.Share.Dtos.Team.Members;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Contracts;

namespace TaskoMask.Presentation.UI.UserPanel.Data
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
