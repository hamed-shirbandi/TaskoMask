using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Identity.Api.Domain.Entities;
using TaskoMask.Services.Identity.Api.Resources;

namespace TaskoMask.Services.Identity.Api.UseCases.UserLogin;

public class UserLoginUseCase : BaseQueryHandler, IRequestHandler<UserLoginRequest, Result>
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserLoginUseCase(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        : base(mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<Result> Handle(UserLoginRequest request, CancellationToken cancellationToken)
    {
        var signInAsync = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, request.RememberLogin, lockoutOnFailure: true);
        if (!signInAsync.Succeeded)
            throw new ApplicationException(ApplicationMessages.Invalid_Credentials);

        var user = await _userManager.FindByNameAsync(request.UserName);
        if (!user.IsActive)
            throw new ApplicationException(ApplicationMessages.Deactive_User_Can_Not_Login);

        await _userManager.AddLoginAsync(user, new UserLoginInfo("local", "local", "local"));

        return Result.Success(ContractsMessages.Operation_Success);
    }
}
