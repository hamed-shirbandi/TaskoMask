using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Identity.Api.Domain.Entities;
using TaskoMask.Services.Identity.Api.Domain.Events;
using TaskoMask.Services.Identity.Api.Resources;

namespace TaskoMask.Services.Identity.Api.UseCases.RegisterUser;

public class RegisterUserUseCase : BaseCommandHandler, IRequestHandler<RegisterUserRequest, CommandResult>
{
    private readonly UserManager<User> _userManager;
    private readonly INotificationService _notifications;

    /// <summary>
    ///
    /// </summary>
    public RegisterUserUseCase(
        UserManager<User> userManager,
        IEventPublisher eventPublisher,
        IRequestDispatcher requestDispatcher,
        INotificationService notifications
    )
        : base(eventPublisher, requestDispatcher)
    {
        _userManager = userManager;
        _notifications = notifications;
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<CommandResult> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var existUser = await _userManager.FindByNameAsync(request.Email);
        if (existUser != null)
            throw new ApplicationException(ApplicationMessages.UserName_Already_Exist);

        var newUser = new User(request.OwnerId)
        {
            Email = request.Email,
            UserName = request.Email,
            IsActive = true,
        };

        var result = await _userManager.CreateAsync(newUser, request.Password);
        if (!result.Succeeded)
        {
            NotifyValidationErrors(result);
            throw new ApplicationException(ContractsMessages.Create_Failed);
        }

        await PublishDomainEventAsync(new UserRegisteredEvent(newUser.Id, newUser.Email));

        await PublishIntegrationEventAsync(new UserRegistered(newUser.Email));

        return CommandResult.Create(ContractsMessages.Create_Success, newUser.Id);
    }

    /// <summary>
    ///
    /// </summary>
    private void NotifyValidationErrors(IdentityResult identityResult)
    {
        var errors = identityResult.Errors.Select(e => e.Description).ToList();

        foreach (var error in errors)
            _notifications.Add(error);
    }
}
