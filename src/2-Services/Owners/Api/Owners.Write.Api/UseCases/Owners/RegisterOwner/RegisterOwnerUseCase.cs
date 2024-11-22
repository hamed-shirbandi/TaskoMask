using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Data;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Entities;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Services;

namespace TaskoMask.Services.Owners.Write.Api.UseCases.Owners.RegisterOwner;

public class RegiserOwnerUseCase : BaseCommandHandler, IRequestHandler<RegiserOwnerRequest, CommandResult>
{
    #region Fields

    private readonly IOwnerAggregateRepository _ownerAggregateRepository;
    private readonly IOwnerValidatorService _ownerValidatorService;

    #endregion

    #region Ctors


    public RegiserOwnerUseCase(
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
    public async Task<CommandResult> Handle(RegiserOwnerRequest request, CancellationToken cancellationToken)
    {
        var owner = Owner.RegisterOwner(request.DisplayName, request.Email, _ownerValidatorService);

        await _ownerAggregateRepository.AddAsync(owner);

        await PublishDomainEventsAsync(owner.DomainEvents);

        //Here a SAGA Choreography is started by consuming OwnerRegistered by identity service
        await PublishIntegrationEventAsync(new OwnerRegistered(owner.Id, owner.Email.Value, request.Password));

        return CommandResult.Create(ContractsMessages.Create_Success, owner.Id);
    }

    #endregion
}
