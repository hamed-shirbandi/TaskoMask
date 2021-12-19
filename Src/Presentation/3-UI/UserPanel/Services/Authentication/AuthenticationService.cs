using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Application.Share.Dtos.Team.Members;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Contracts;

namespace TaskoMask.Presentation.UI.UserPanel.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly IAccountClientService _accountClientService;

        #endregion

        #region Ctor

        public AuthenticationService(IAccountClientService accountClientService)
        {
            _accountClientService = accountClientService;
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public Task<Result<string>> Login(UserLoginDto input)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// 
        /// </summary>
        public Task<Result<CommandResult>> Register(MemberRegisterDto input)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// 
        /// </summary>
        public void Logout()
        {
            throw new NotImplementedException();
        }



        #endregion

        #region Private Methods



        #endregion

    }
}