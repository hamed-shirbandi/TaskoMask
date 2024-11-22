using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Data;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Services;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.ValueObjects.Owners;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Owners.UpdateOwnerProfile;

public class UpdateOwnerProfileUseCase : BaseCommandHandler, IRequestHandler<UpdateOwnerProfileRequest, CommandResult>
{
    #region Fields

    private readonly IOwnerAggregateRepository _ownerAggregateRepository;
    private readonly IOwnerValidatorService _ownerValidatorService;

    #endregion

    #region Ctors


    public UpdateOwnerProfileUseCase(
        IOwnerAggregateRepository ownerAggregateRepository,
        IOwnerValidatorService ownerValidatorService,
        IEventPublisher eventPublisher,
        IRequestDispatcher requestDispatcher
    )
        : base(eventPublisher, requestDispatcher)
    {
        _ownerAggregateRepository = ownerAggregateRepository;
        _ownerValidatorService = ownerValidatorService;
    }

    #endregion

    #region Handlers



    /// <summary>
    ///
    /// </summary>
    public async Task<CommandResult> Handle(UpdateOwnerProfileRequest request, CancellationToken cancellationToken)
    {
        var owner = await _ownerAggregateRepository.GetByIdAsync(request.Id);
        if (owner == null)
            throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

        var oldEmail = owner.Email.Value;
        var loadedVersion = owner.Version;

        owner.UpdateOwnerProfile(OwnerDisplayName.Create(request.DisplayName), OwnerEmail.Create(request.Email), _ownerValidatorService);

        await _ownerAggregateRepository.ConcurrencySafeUpdate(owner, loadedVersion);

        await PublishDomainEventsAsync(owner.DomainEvents);

        //Here a SAGA Choreography is started by consuming OwnerProfileUpdated by identity service
        await PublishIntegrationEventAsync(new OwnerProfileUpdated(owner.Id, oldEmail, NewEmail: owner.Email.Value));

        return CommandResult.Create(ContractsMessages.Update_Success, owner.Id.ToString());
    }

    #endregion
}
