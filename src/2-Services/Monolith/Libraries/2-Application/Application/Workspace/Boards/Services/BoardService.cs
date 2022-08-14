﻿using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Commands.Models;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Queries.Models;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Boards;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.Services.Monolith.Application.Queries.Models.Boards;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Infrastructure.Bus;
using TaskoMask.Services.Monolith.Application.Workspace.Cards.Services;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.Services.Monolith.Application.Workspace.Boards.Services
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
        public async Task<Result<CommandResult>> AddAsync(AddBoardDto input)
        {
            var cmd = new AddBoardCommand(name: input.Name, input.Description, input.ProjectId);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(UpdateBoardDto input)
        {
            var cmd = new UpdateBoardCommand(id: input.Id, name: input.Name, description: input.Description);
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
            var boardQueryResult = await GetByIdAsync(id);
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
        public async Task<Result<PaginatedList<BoardOutputDto>>> SearchAsync(int page, int recordsPerPage, string term)
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
