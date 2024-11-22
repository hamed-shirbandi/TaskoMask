using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Commands;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Events;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Data;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Entities;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Events.Boards;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Services;

namespace TaskoMask.Services.Boards.Write.Api.UseCases.Boards.AddBoard;

public class AddBoardUseCase : BaseCommandHandler, IRequestHandler<AddBoardRequest, CommandResult>
{
    #region Fields

    private readonly IBoardAggregateRepository _boardAggregateRepository;
    private readonly IBoardValidatorService _boardValidatorService;

    #endregion

    #region Ctors


    public AddBoardUseCase(
        IBoardAggregateRepository boardAggregateRepository,
        IEventPublisher eventPublisher,
        IRequestDispatcher requestDispatcher,
        IBoardValidatorService boardValidatorService
    )
        : base(eventPublisher, requestDispatcher)
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
        var board = Board.AddBoard(request.Name, request.Description, request.ProjectId, _boardValidatorService);

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
        return new BoardAdded(
            boardAddedDomainEvent.Id,
            boardAddedDomainEvent.Name,
            boardAddedDomainEvent.Description,
            boardAddedDomainEvent.ProjectId
        );
    }

    #endregion
}
