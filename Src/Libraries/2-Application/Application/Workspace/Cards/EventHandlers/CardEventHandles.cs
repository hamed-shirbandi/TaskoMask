using MediatR;
using System.Threading;
using TaskoMask.Domain.DataModel.Data;
using TaskoMask.Domain.DataModel.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Events.Cards;

namespace TaskoMask.Application.Workspace.Cards.EventHandlers
{
    /// <summary>
    /// Sync data between Write and Read DB
    /// </summary>
    public class CardEventHandles : 
        INotificationHandler<CardCreatedEvent>,
        INotificationHandler<CardUpdatedEvent>,
        INotificationHandler<CardDeletedEvent>,
        INotificationHandler<CardRecycledEvent>
    {
        #region Fields

        private readonly ICardRepository _cardRepository;
        private readonly IBoardRepository _boardRepository;

        #endregion

        #region Ctors

        public CardEventHandles(ICardRepository cardRepository, IBoardRepository boardRepository)
        {
            _cardRepository = cardRepository;
            _boardRepository = boardRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(CardCreatedEvent createdCard, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetByIdAsync(createdCard.BoardId);
            var card = new Card(createdCard.Id)
            {
                Name= createdCard.Name,
                Type= createdCard.Type,
                BoardId= createdCard.BoardId,
                OrganizationId= board.OrganizationId,
                OwnerId= board.OwnerId,
            };
           await _cardRepository.CreateAsync(card);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(CardUpdatedEvent updatedCard, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetByIdAsync(updatedCard.Id);

            card.Name = updatedCard.Name;
            card.Type = updatedCard.Type;

            card.SetAsUpdated();

            await _cardRepository.UpdateAsync(card);

        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(CardDeletedEvent deletedCard, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetByIdAsync(deletedCard.Id);
            card.SetAsDeleted();
            await _cardRepository.UpdateAsync(card);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(CardRecycledEvent recycledCard, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetByIdAsync(recycledCard.Id);
            card.SetAsRecycled();
            await _cardRepository.UpdateAsync(card);
        }

        #endregion






    }
}
