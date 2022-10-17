using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Owners.Write.Domain.Data;
using TaskoMask.Services.Owners.Write.Domain.Entities;
using TaskoMask.Services.Owners.Write.Domain.Services;

namespace TaskoMask.Services.Owners.Write.Application.UseCases.Owners.RegiserOwner
{
    public class RegiserOwnerUseCase : BaseCommandHandler, IRequestHandler<RegiserOwnerRequest, CommandResult>

    {
        #region Fields

        private readonly IOwnerAggregateRepository _ownerAggregateRepository;
        private readonly IOwnerValidatorService _ownerValidatorService;

        #endregion

        #region Ctors


        public RegiserOwnerUseCase(IOwnerAggregateRepository ownerAggregateRepository, IInMemoryBus inMemoryBus, IOwnerValidatorService ownerValidatorService) : base(inMemoryBus)
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

            await _ownerAggregateRepository.CreateAsync(owner);

            await PublishDomainEventsAsync(owner.DomainEvents);

            //TODO publish OwnerRegisteredEvent (to be handled by Identity service)

            return CommandResult.Create(ContractsMessages.Create_Success, owner.Id.ToString());
        }



        #endregion

    }
}
