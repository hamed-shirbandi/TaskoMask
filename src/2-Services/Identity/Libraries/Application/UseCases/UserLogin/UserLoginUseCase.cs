using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Identity.Application.Resources;
using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.Application.UseCases.UserLogin
{
    public class UserLoginUseCase : BaseCommandHandler, IRequestHandler<UserLoginRequest, CommandResult>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public UserLoginUseCase(UserManager<User> userManager, SignInManager<User> signInManager, IInMemoryBus inMemoryBus) : base(inMemoryBus)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<CommandResult> Handle(UserLoginRequest request, CancellationToken cancellationToken)
        {
            var signInAsync = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, request.RememberLogin, lockoutOnFailure: true);
            if (!signInAsync.Succeeded)
                throw new ApplicationException(ApplicationMessages.Invalid_Credentials);

            var user = await _userManager.FindByNameAsync(request.UserName);
            if (!user.IsActive)
                throw new ApplicationException(ApplicationMessages.Deactive_User_Can_Not_Login);

            await _userManager.AddLoginAsync(user, new UserLoginInfo("local", "local", "local"));

            return CommandResult.Create(ContractsMessages.Operation_Success);

        }
    }
}
