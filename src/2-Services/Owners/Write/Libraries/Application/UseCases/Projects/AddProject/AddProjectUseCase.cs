using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Domain.Data;
using TaskoMask.Services.Owners.Write.Domain.Entities;
using TaskoMask.Services.Owners.Write.Domain.Services;

namespace TaskoMask.Services.Owners.Write.Application.UseCases.Projects.AddProject
{
    public class AddProjectUseCase : BaseCommandHandler, IRequestHandler<AddProjectRequest, CommandResult>

    {
        #region Fields

        private readonly IOwnerAggregateRepository _ownerAggregateRepository;
        private readonly IOwnerValidatorService _ownerValidatorService;

        #endregion

        #region Ctors


        public AddProjectUseCase(IOwnerAggregateRepository ownerAggregateRepository, IMessageBus messageBus, IOwnerValidatorService ownerValidatorService, IInMemoryBus inMemoryBus) : base(messageBus,inMemoryBus)
        {
            _ownerAggregateRepository = ownerAggregateRepository;
            _ownerValidatorService = ownerValidatorService;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(AddProjectRequest request, CancellationToken cancellationToken)
        {
            var owner = await _ownerAggregateRepository.GetByOrganizationIdAsync(request.OrganizationId);
            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            var project = Project.Create(request.Name, request.Description);
            owner.AddProject(request.OrganizationId, project);

            await _ownerAggregateRepository.UpdateAsync(owner);
            await PublishDomainEventsAsync(owner.DomainEvents);

            return new CommandResult(ContractsMessages.Create_Success, project.Id);
        }



        #endregion

    }
}
