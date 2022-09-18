using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
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
            var user = new User
            {
                Email=request.Email,
                UserName=request.Email,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return Result.Failure(errors: errors, message: ContractsMessages.Create_Failed);
            }

            return Result.Success();
        }
    }
}
