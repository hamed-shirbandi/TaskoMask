using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Threading.Tasks;
using TaskoMask.Application.Cards.Commands.Models;
using TaskoMask.Application.Boards.Queries.Models;
using TaskoMask.Application.Cards.Queries.Models;
using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Application.Core.ViewMoldes;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Queries.Models.Boards;
using TaskoMask.Application.Core.Dtos.Boards;
using System.Collections.Generic;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Domain.Entities;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Application.Projects.Queries.Models;
using TaskoMask.Application.Organizations.Queries.Models;
using TaskoMask.Application.Tasks.Queries.Models;
using TaskoMask.Application.Core.Bus;

namespace TaskoMask.Application.Cards.Services
{
    public class CardService : BaseEntityService<Card>, ICardService
    {

        #region Fields


        #endregion

        #region Ctor

        public CardService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        { }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CardDetailViewModel>> GetDetailAsync(string id)
        {
            var cardQueryResult = await SendQueryAsync(new GetCardByIdQuery(id));
            if (!cardQueryResult.IsSuccess)
                return Result.Failure<CardDetailViewModel>(cardQueryResult.Errors);


            var boardQueryResult = await SendQueryAsync(new GetBoardByIdQuery(cardQueryResult.Value.BoardId));
            if (!boardQueryResult.IsSuccess)
                return Result.Failure<CardDetailViewModel>(boardQueryResult.Errors);


            var projectQueryResult = await SendQueryAsync(new GetProjectByIdQuery(boardQueryResult.Value.ProjectId));
            if (!projectQueryResult.IsSuccess)
                return Result.Failure<CardDetailViewModel>(projectQueryResult.Errors);


            var organizationQueryResult = await SendQueryAsync(new GetOrganizationByIdQuery(projectQueryResult.Value.OrganizationId));
            if (!organizationQueryResult.IsSuccess)
                return Result.Failure<CardDetailViewModel>(organizationQueryResult.Errors);




            var cardReportQueryResult = await SendQueryAsync(new GetCardReportQuery(id));
            if (!cardReportQueryResult.IsSuccess)
                return Result.Failure<CardDetailViewModel>(cardReportQueryResult.Errors);


            var taskQueryResult = await SendQueryAsync(new GetTasksByCardIdQuery(id));
            if (!taskQueryResult.IsSuccess)
                return Result.Failure<CardDetailViewModel>(taskQueryResult.Errors);



            var cardDetail = new CardDetailViewModel
            {
                Organization = organizationQueryResult.Value,
                Project = projectQueryResult.Value,
                Board = boardQueryResult.Value,
                Reports = cardReportQueryResult.Value,
                Card = cardQueryResult.Value,
                Tasks = taskQueryResult.Value,
            };

            return Result.Success(cardDetail);

        }

        #endregion


    }
}
