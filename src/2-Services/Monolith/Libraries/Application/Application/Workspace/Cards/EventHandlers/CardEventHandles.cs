using MediatR;
using System.Threading;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Events.Cards;

namespace TaskoMask.Services.Monolith.Application.Workspace.Cards.EventHandlers
{
    /// <summary>
    /// Sync data between Write and Read DB
    /// </summary>
    public class CardEventHandles : 
        INotificationHandler<CardAddedEvent>,
        INotificationHandler<CardUpdatedEvent>,
        INotificationHandler<CardDeletedEvent>
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
        public async System.Threading.Tasks.Task Handle(CardAddedEvent createdCard, CancellationToken cancellationToken)
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
           await _cardRepository.AddAsync(card);
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
            await _cardRepository.DeleteAsync(deletedCard.Id);
        }



        #endregion






    }
}
