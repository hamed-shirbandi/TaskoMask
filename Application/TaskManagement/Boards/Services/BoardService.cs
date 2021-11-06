using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.TaskManagement.Boards.Commands.Models;
using TaskoMask.Application.TaskManagement.Boards.Queries.Models;
using TaskoMask.Application.Team.Projects.Queries.Models;
using TaskoMask.Application.Core.Dtos.TaskManagement.Boards;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Queries.Models.Boards;
using System.Collections.Generic;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Team.Organizations.Queries.Models;
using TaskoMask.Application.TaskManagement.Cards.Queries.Models;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Common.Base.Services;
using TaskoMask.Domain.TaskManagement.Entities;

namespace TaskoMask.Application.TaskManagement.Boards.Services
{
    public class BoardService :BaseService<Board>, IBoardService
    {
        #region Fields


        #endregion

        #region Ctors

        public BoardService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        { }



        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(BoardUpsertDto input)
        {
            var cmd = new CreateBoardCommand(projectId: input.ProjectId, name: input.Name, description: input.Description);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(BoardUpsertDto input)
        {
            var cmd = new UpdateBoardCommand(id: input.Id, name: input.Name, description: input.Description);
            return await SendCommandAsync(cmd);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<BoardBasicInfoDto>> GetByIdAsync(string id)
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


            var projectQueryResult = await SendQueryAsync(new GetProjectByIdQuery(boardQueryResult.Value.ProjectId));
            if (!projectQueryResult.IsSuccess)
                return Result.Failure<BoardDetailsViewModel>(projectQueryResult.Errors);


            var organizationQueryResult = await SendQueryAsync(new GetOrganizationByIdQuery(projectQueryResult.Value.OrganizationId));
            if (!organizationQueryResult.IsSuccess)
                return Result.Failure<BoardDetailsViewModel>(organizationQueryResult.Errors);



            var cardQueryResult = await SendQueryAsync(new GetCardsByBoardIdQuery(id));
            if (!cardQueryResult.IsSuccess)
                return Result.Failure<BoardDetailsViewModel>(cardQueryResult.Errors);


            var boardReportQueryResult = await SendQueryAsync(new GetBoardReportQuery(id));
            if (!boardReportQueryResult.IsSuccess)
                return Result.Failure<BoardDetailsViewModel>(boardReportQueryResult.Errors);



            var boardDetail = new BoardDetailsViewModel
            {
                Organization = organizationQueryResult.Value,
                Project = projectQueryResult.Value,
                Board = boardQueryResult.Value,
                Reports = boardReportQueryResult.Value,
                Cards = cardQueryResult.Value,
            };

            return Result.Success(boardDetail);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<BoardBasicInfoDto>>> GetListByProjectIdAsync(string projectId)
        {
            return await SendQueryAsync(new GetBoardsByProjectIdQuery(projectId));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<BoardReportDto>> GetReportAsync(string id)
        {
            return await SendQueryAsync(new GetBoardReportQuery(id));

        }





        #endregion

    }
}
