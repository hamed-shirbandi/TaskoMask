using MediatR;
using System.Threading;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Events.Cards;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Tasks.Events.Tasks;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.EventHandlers
{
    /// <summary>
    /// Sync data between Write and Read DB
    /// </summary>
    public class TaskEventHandles : 
        INotificationHandler<TaskAddedEvent>,
        INotificationHandler<TaskUpdatedEvent>,
        INotificationHandler<TaskDeletedEvent>,
        INotificationHandler<TaskMovedToAnotherCardEvent>,
        INotificationHandler<CardUpdatedEvent>
    {
        #region Fields

        private readonly ITaskRepository _taskRepository;
        private readonly IBoardRepository _boardRepository;
        private readonly ICardRepository _cardRepository;

        #endregion

        #region Ctors

        public TaskEventHandles(ITaskRepository taskRepository, IBoardRepository boardRepository, ICardRepository cardRepository)
        {
            _taskRepository = taskRepository;
            _boardRepository = boardRepository;
            _cardRepository = cardRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskAddedEvent createdTask, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetByIdAsync(createdTask.BoardId);
            var card = await _cardRepository.GetByIdAsync(createdTask.CardId);

            var task = new Task(createdTask.Id)
            {
                Title= createdTask.Title,
                Description= createdTask.Description,
                CardId= createdTask.CardId,
                BoardId = createdTask.BoardId,
                OrganizationId= board.OrganizationId,
                OwnerId= board.OwnerId,
                CardType= card.Type,
            };
           await _taskRepository.AddAsync(task);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskUpdatedEvent updatedTask, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(updatedTask.Id);

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;

            task.SetAsUpdated();

            await _taskRepository.UpdateAsync(task);

        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskDeletedEvent deletedTask, CancellationToken cancellationToken)
        {
            await _taskRepository.DeleteAsync(deletedTask.Id);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(TaskMovedToAnotherCardEvent movedToAnotherCardEvent, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(movedToAnotherCardEvent.TaskId);
            var card = await _cardRepository.GetByIdAsync(movedToAnotherCardEvent.CardId);

            task.CardId= movedToAnotherCardEvent.CardId;
            task.CardType= card.Type;

            await _taskRepository.UpdateAsync(task);
        }



        /// <summary>
        /// update cardType for all tasks in a card when the cardType for that card is changed
        /// </summary>
        public async System.Threading.Tasks.Task Handle(CardUpdatedEvent updatedCard, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetByIdAsync(updatedCard.Id);

            if (card.Type!=updatedCard.Type)
            {
                await _taskRepository.BulkUpdateCardTypeByCardIdAsync(card.Id, updatedCard.Type);
            }

        }


        #endregion






    }
}
