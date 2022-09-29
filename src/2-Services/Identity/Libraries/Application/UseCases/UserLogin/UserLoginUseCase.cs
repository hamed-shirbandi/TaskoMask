using Duende.IdentityServer.Events;
using Duende.IdentityServer.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Identity.Application.Resources;
using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.Application.UseCases.UserLogin
{
    public class UserLoginUseCase : IRequestHandler<UserLoginRequest, Result>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public UserLoginUseCase(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<Result> Handle(UserLoginRequest request, CancellationToken cancellationToken)
        {
            var signInAsync = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, request.RememberLogin, lockoutOnFailure: true);
            if (!signInAsync.Succeeded)
                return Result.Failure(message: ApplicationMessages.Invalid_Credentials);

            var user = await _userManager.FindByNameAsync(request.UserName);
            if (!user.IsActive)
                return Result.Failure(message: ApplicationMessages.Deactive_User_Can_Not_Login);

            await _userManager.AddLoginAsync(user, new UserLoginInfo("local", "local", "local"));

            return Result.Success();
        }
    }
}
