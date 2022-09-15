using Duende.IdentityServer.Events;
using Duende.IdentityServer.Models;
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
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IEventService _events;


        public UserLoginUseCase(IIdentityServerInteractionService interaction, IEventService events, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _events = events;
        }


        public async Task<Result> Handle(UserLoginRequest request, CancellationToken cancellationToken)
        {
            var context = await _interaction.GetAuthorizationContextAsync(request.ReturnUrl);

            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, request.RememberLogin, lockoutOnFailure: true);
            if (!result.Succeeded)
            {
                await _events.RaiseAsync(new UserLoginFailureEvent(request.Username, "invalid credentials", clientId: context?.Client.ClientId));
                return Result.Failure(message: ApplicationMessages.InvalidCredentialsErrorMessage);
            }

            var user = await _userManager.FindByNameAsync(request.Username);
            await _userManager.AddLoginAsync(user, new UserLoginInfo("local", "local", "local"));
            await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName, clientId: context?.Client.ClientId));

            return Result.Success();
        }
    }
}
