using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Owners.Write.Domain.Data;
using TaskoMask.Services.Owners.Write.Domain.Entities;

namespace TaskoMask.Services.Owners.Write.Application.UseCases.Owners.RegiserOwner
{
    public class RegiserOwnerUseCase : BaseCommandHandler, IRequestHandler<RegiserOwnerRequest, CommandResult>

    {
        #region Fields

        private readonly IOwnerAggregateRepository _ownerAggregateRepository;

        #endregion

        #region Ctors


        public RegiserOwnerUseCase(IOwnerAggregateRepository ownerAggregateRepository, IInMemoryBus inMemoryBus) : base(inMemoryBus)
        {
            _ownerAggregateRepository = ownerAggregateRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(RegiserOwnerRequest request, CancellationToken cancellationToken)
        {
            var owner = Owner.RegisterOwner(request.DisplayName, request.Email);

            await _ownerAggregateRepository.CreateAsync(owner);

            await PublishDomainEventsAsync(owner.DomainEvents);

            //TODO publish OwnerRegisteredEvent (to be handled by Identity service)

            return new CommandResult(ContractsMessages.Create_Success, owner.Id.ToString());
        }



        #endregion

    }
}
