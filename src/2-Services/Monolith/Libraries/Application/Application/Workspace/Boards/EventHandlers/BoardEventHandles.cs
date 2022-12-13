using MediatR;
using System.Threading;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Events.Boards;

namespace TaskoMask.Services.Monolith.Application.Workspace.Boards.EventHandlers
{
    /// <summary>
    /// Sync data between Write and Read DB
    /// </summary>
    public class BoardEventHandles : 
        INotificationHandler<BoardAddedEvent>,
        INotificationHandler<BoardUpdatedEvent>,
        INotificationHandler<BoardDeletedEvent>
    {
        #region Fields

        private readonly IBoardRepository _boardRepository;

        #endregion

        #region Ctors

        public BoardEventHandles(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        #endregion

        #region Handlers


        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(BoardAddedEvent createdBoard, CancellationToken cancellationToken)
        {
            //TODO get project data from owner read service
           // var project = await _projectRepository.GetByIdAsync(createdBoard.ProjectId);

            var board = new Board(createdBoard.Id)
            {
                Name= createdBoard.Name,
                Description= createdBoard.Description,
              //  OrganizationId= project.OrganizationId,
                ProjectId = createdBoard.ProjectId,
              //  OwnerId= project.OwnerId,
            };
           await _boardRepository.AddAsync(board);
        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(BoardUpdatedEvent updatedBoard, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetByIdAsync(updatedBoard.Id);

            board.Name = updatedBoard.Name;
            board.Description = updatedBoard.Description;

            board.SetAsUpdated();

            await _boardRepository.UpdateAsync(board);

        }



        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task Handle(BoardDeletedEvent deletedBoard, CancellationToken cancellationToken)
        {
            await _boardRepository.DeleteAsync(deletedBoard.Id);
        }



        #endregion






    }
}
