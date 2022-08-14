using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Cards.Commands.Models;
using TaskoMask.Services.Monolith.Application.Share.Resources;
using TaskoMask.Services.Monolith.Application.Core.Commands;
using TaskoMask.Services.Monolith.Application.Core.Notifications;
using TaskoMask.Services.Monolith.Application.Core.Exceptions;
using TaskoMask.Services.Monolith.Domain.Share.Resources;
using MediatR;
using TaskoMask.Services.Monolith.Application.Core.Bus;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;

namespace TaskoMask.Services.Monolith.Application.Workspace.Cards.Commands.Handlers
{
    public class CardCommandHandlers : BaseCommandHandler,
        IRequestHandler<AddCardCommand, CommandResult>,
         IRequestHandler<UpdateCardCommand, CommandResult>,
         IRequestHandler<DeleteCardCommand, CommandResult>
    {
        #region Fields

        private readonly IBoardAggregateRepository _boardAggregateRepository;


        #endregion

        #region Ctors

        public CardCommandHandlers(IBoardAggregateRepository boardAggregateRepository, IInMemoryBus inMemoryBus) : base(inMemoryBus)
        {
            _boardAggregateRepository = boardAggregateRepository;
        }


        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(AddCardCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardAggregateRepository.GetByIdAsync(request.BoardId);
            if (board == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Board);

            var card = Card.Create(name: request.Name, type: request.Type);
            board.AddCard(card);

            await _boardAggregateRepository.UpdateAsync(board);
            await PublishDomainEventsAsync(board.DomainEvents);

            return new CommandResult(ApplicationMessages.Create_Success, card.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardAggregateRepository.GetByCardIdAsync(request.Id);
            if (board == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Board);

            var loadedVersion = board.Version;

            board.UpdateCard(request.Id, request.Name, request.Type);

            await _boardAggregateRepository.ConcurrencySafeUpdate(board, loadedVersion);

            await PublishDomainEventsAsync(board.DomainEvents);

            return new CommandResult(ApplicationMessages.Update_Success, request.Id);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            var board = await _boardAggregateRepository.GetByCardIdAsync(request.Id);
            if (board == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Board);

            var loadedVersion = board.Version;

            board.DeleteCard(request.Id);

            await _boardAggregateRepository.ConcurrencySafeUpdate(board, loadedVersion);

            await PublishDomainEventsAsync(board.DomainEvents);

            return new CommandResult(ApplicationMessages.Update_Success, board.Id);

        }

        #endregion

    }
}
