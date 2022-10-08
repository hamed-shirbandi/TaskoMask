using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Identity.Application.Resources;
using TaskoMask.Services.Identity.Domain.Entities;

namespace TaskoMask.Services.Identity.Application.UseCases.RegisterNewUser
{
    public class RegisterNewUserUseCase : IRequestHandler<RegisterNewUserRequest, Result>
    {
        private readonly UserManager<User> _userManager;


        public RegisterNewUserUseCase(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        public async Task<Result> Handle(RegisterNewUserRequest request, CancellationToken cancellationToken)
        {
            var existUser = await _userManager.FindByNameAsync(request.Email);
            if (existUser != null)
                return Result.Failure(message: ApplicationMessages.UserName_Already_Exist);

            var newUser = new User
            {
                Email = request.Email,
                UserName = request.Email,
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return Result.Failure(errors: errors, message: ContractsMessages.Create_Failed);
            }

            //TODO publish NewUserRegistered event

            return Result.Success();
        }
    }
}
