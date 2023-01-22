using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.Services.Boards.Write.Domain.Data;
using TaskoMask.Services.Boards.Write.Domain.Entities;
using TaskoMask.Services.Boards.Write.Domain.Events.Boards;
using TaskoMask.Services.Boards.Write.Domain.Services;

namespace TaskoMask.Services.Boards.Write.Application.UseCases.Boards.AddBoard
{
    public class AddBoardUseCase : BaseCommandHandler, IRequestHandler<AddBoardRequest, CommandResult>

    {
        #region Fields

        private readonly IBoardAggregateRepository _boardAggregateRepository;
        private readonly IBoardValidatorService _boardValidatorService;

        #endregion

        #region Ctors


        public AddBoardUseCase(IBoardAggregateRepository boardAggregateRepository, IMessageBus messageBus, IInMemoryBus inMemoryBus, IBoardValidatorService boardValidatorService) : base(messageBus, inMemoryBus)
        {
            _boardAggregateRepository = boardAggregateRepository;
            _boardValidatorService = boardValidatorService;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(AddBoardRequest request, CancellationToken cancellationToken)
        {

            var board = Board.AddBoard(request.Name, request.Description,request.ProjectId, _boardValidatorService);

            await _boardAggregateRepository.AddAsync(board);

            await PublishDomainEventsAsync(board.DomainEvents);

            var boardAdded = MapToBoardAddedIntegrationEvent(board.DomainEvents);

            await PublishIntegrationEventAsync(boardAdded);

            return CommandResult.Create(ContractsMessages.Create_Success, board.Id);
        }


        #endregion

        #region Private Methods


        private BoardAdded MapToBoardAddedIntegrationEvent(IReadOnlyCollection<DomainEvent> domainEvents)
        {
            var boardAddedDomainEvent = (BoardAddedEvent)domainEvents.FirstOrDefault(e => e.EventType == nameof(BoardAddedEvent));
            return new BoardAdded(boardAddedDomainEvent.Id, boardAddedDomainEvent.Name, boardAddedDomainEvent.Description, boardAddedDomainEvent.ProjectId);
        }


        #endregion

    }
}
