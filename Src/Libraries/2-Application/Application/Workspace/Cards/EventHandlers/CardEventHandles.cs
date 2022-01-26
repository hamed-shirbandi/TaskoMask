using MediatR;
using System.Threading;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.ReadModel.Entities;
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

        #endregion

        #region Ctors

        public CardEventHandles(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(CardCreatedEvent createdCard, CancellationToken cancellationToken)
        {
            var card = new Card(createdCard.Id)
            {
                Name= createdCard.Name,
                Type= createdCard.Type,
                BoardId= createdCard.BoardId,
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
            card.SetAsDeleteed();
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
