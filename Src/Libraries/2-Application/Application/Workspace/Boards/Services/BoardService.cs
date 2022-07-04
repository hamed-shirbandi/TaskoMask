using AutoMapper;
using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Boards.Commands.Models;
using TaskoMask.Application.Workspace.Boards.Queries.Models;
using TaskoMask.Application.Share.Dtos.Workspace.Boards;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Application.Queries.Models.Boards;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Workspace.Cards.Services;

namespace TaskoMask.Application.Workspace.Boards.Services
{
    public class BoardService :ApplicationService, IBoardService
    {
        #region Fields

        private readonly ICardService _cardService;

        #endregion

        #region Ctors

        public BoardService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications, ICardService cardService) : base(inMemoryBus, mapper, notifications)
        {
            _cardService = cardService;
        }



        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(BoardUpsertDto input)
        {
            var cmd = new CreateBoardCommand(name: input.Name, input.Description, input.ProjectId);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(BoardUpsertDto input)
        {
            var cmd = new UpdateBoardCommand(id: input.Id, name: input.Name, description: input.Description, projectId: input.ProjectId);
            return await SendCommandAsync(cmd);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<BoardOutputDto>> GetByIdAsync(string id)
        {
            return await SendQueryAsync(new GetBoardByIdQuery(id));

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<BoardDetailsViewModel>> GetDetailsAsync(string id)
        {
            var boardQueryResult = await SendQueryAsync(new GetBoardByIdQuery(id));
            if (!boardQueryResult.IsSuccess)
                return Result.Failure<BoardDetailsViewModel>(boardQueryResult.Errors);

            var cardQueryResult = await _cardService.GetListWithDetailsByBoardIdAsync(id);
            if (!cardQueryResult.IsSuccess)
                return Result.Failure<BoardDetailsViewModel>(cardQueryResult.Errors);


            var boardDetail = new BoardDetailsViewModel
            {
                Board = boardQueryResult.Value,
                Cards = cardQueryResult.Value,
            };

            return Result.Success(boardDetail);

        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<PaginatedListReturnType<BoardOutputDto>>> SearchAsync(int page, int recordsPerPage, string term)
        {
            return await SendQueryAsync(new SearchBoardsQuery(page, recordsPerPage, term));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<long>> CountAsync()
        {
            return await SendQueryAsync(new GetBoardsCountQuery());
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var cmd = new DeleteBoardCommand(id);
            return await SendCommandAsync(cmd);
        }




        #endregion

    }
}
