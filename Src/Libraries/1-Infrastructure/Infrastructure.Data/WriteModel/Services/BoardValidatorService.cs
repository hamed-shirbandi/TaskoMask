using TaskoMask.Domain.WriteModel.Workspace.Boards.Data;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Services;

namespace TaskoMask.Infrastructure.Data.WriteModel.Services
{

    /// <summary>
    /// 
    /// </summary>
    public class BoardValidatorService : IBoardValidatorService
    {
        private readonly IBoardAggregateRepository _boardRepository;

        public BoardValidatorService(IBoardAggregateRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }


        /// <summary>
        /// 
        /// </summary>
        public bool BoardHasUniqueName(string boardId, string projectId, string boardName)
        {
            return !_boardRepository.ExistBoard(boardId, projectId, boardName);
        }
    }
}
