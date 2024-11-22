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
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Identity.Api.Domain.Entities;
using TaskoMask.Services.Identity.Api.Domain.Events;

namespace TaskoMask.Services.Identity.Api.UseCases.UpdateUser;

public class UpdateUserUseCase : BaseCommandHandler, IRequestHandler<UpdateUserRequest, CommandResult>
{
    private readonly UserManager<User> _userManager;
    private readonly INotificationService _notifications;

    /// <summary>
    ///
    /// </summary>
    public UpdateUserUseCase(
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
    public async Task<CommandResult> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.OldEmail);
        if (user == null)
            throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.User);

        user.Email = request.NewEmail;
        user.UserName = request.NewEmail;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            NotifyValidationErrors(result);
            throw new ApplicationException(ContractsMessages.Update_Failed);
        }

        await PublishDomainEventAsync(new UserUpdatedEvent(user.Id, user.Email));

        await PublishIntegrationEventAsync(new UserUpdated(user.Email));

        return CommandResult.Create(ContractsMessages.Update_Success, user.Id);
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
