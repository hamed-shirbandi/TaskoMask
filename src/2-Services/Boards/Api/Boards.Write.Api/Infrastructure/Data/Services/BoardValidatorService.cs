
using TaskoMask.Services.Boards.Write.Api.Domain.Data;
using TaskoMask.Services.Boards.Write.Api.Domain.Services;

namespace TaskoMask.Services.Boards.Write.Api.Infrastructure.Data.Services
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
