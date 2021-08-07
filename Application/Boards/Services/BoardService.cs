using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Threading.Tasks;
using TaskoMask.Application.Boards.Commands.Models;
using TaskoMask.Application.Boards.Queries.Models;
using TaskoMask.Application.Projects.Queries.Models;
using TaskoMask.Application.Core.Dtos.Boards;
using TaskoMask.Application.Core.ViewMoldes;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Queries.Models.Boards;
using TaskoMask.Application.Core.Dtos.Projects;
using System.Collections.Generic;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Domain.Core.Notifications;
using System.Linq;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Organizations.Queries.Models;
using TaskoMask.Application.Cards.Queries.Models;

namespace TaskoMask.Application.Boards.Services
{
    public class BoardService : BaseEntityService<Board>, IBoardService
    {
        #region Fields


        #endregion

        #region Ctor

        public BoardService(IMediator mediator, IMapper mapper, IDomainNotificationHandler notifications) : base(mediator, mapper, notifications)
        { }

        #endregion



        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<BoardDetailViewModel>> GetDetailAsync(string id)
        {
            var boardQueryResult = await SendQueryAsync(new GetBoardByIdQuery(id));
            if (!boardQueryResult.IsSuccess)
                return Result.Failure<BoardDetailViewModel>(boardQueryResult.Errors);


            var projectQueryResult = await SendQueryAsync(new GetProjectByIdQuery(boardQueryResult.Value.ProjectId));
            if (!projectQueryResult.IsSuccess)
                return Result.Failure<BoardDetailViewModel>(projectQueryResult.Errors);


            var organizationQueryResult = await SendQueryAsync(new GetOrganizationByIdQuery(projectQueryResult.Value.OrganizationId));
            if (!organizationQueryResult.IsSuccess)
                return Result.Failure<BoardDetailViewModel>(organizationQueryResult.Errors);



            var cardQueryResult = await SendQueryAsync(new GetCardsByBoardIdQuery(id));
            if (!cardQueryResult.IsSuccess)
                return Result.Failure<BoardDetailViewModel>(cardQueryResult.Errors);


            var boardReportQueryResult = await SendQueryAsync(new GetBoardReportQuery(id));
            if (!boardReportQueryResult.IsSuccess)
                return Result.Failure<BoardDetailViewModel>(boardReportQueryResult.Errors);



            var boardDetail = new BoardDetailViewModel
            {
                Organization = organizationQueryResult.Value,
                Project = projectQueryResult.Value,
                Board = boardQueryResult.Value,
                Reports = boardReportQueryResult.Value,
                Cards = cardQueryResult.Value,
            };

            return Result.Success(boardDetail);

        }




        #endregion

    }
}
