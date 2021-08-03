using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Threading.Tasks;
using TaskoMask.Application.Projects.Commands.Models;
using TaskoMask.Application.Organizations.Queries.Models;
using TaskoMask.Application.Projects.Queries.Models;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Application.Core.ViewMoldes;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Services;
using System.Collections.Generic;
using TaskoMask.Application.Core.Dtos.Organizations;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Domain.Entities;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Application.Boards.Queries.Models;

namespace TaskoMask.Application.Projects.Services
{
    public class ProjectService : BaseEntityService<Project>, IProjectService
    {

        #region Fields


        #endregion

        #region Ctor

        public ProjectService(IMediator mediator, IMapper mapper, INotificationHandler<DomainNotification> notifications) : base(mediator, mapper, notifications)
        { }


        #endregion


        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<ProjectDetailViewModel>> GetDetailAsync(string id)
        {
            var projectQueryResult = await SendQueryAsync(new GetProjectByIdQuery(id));
            if (!projectQueryResult.IsSuccess)
                return Result.Failure<ProjectDetailViewModel>(projectQueryResult.Errors);


            var organizationQueryResult = await SendQueryAsync(new GetOrganizationByIdQuery(projectQueryResult.Value.OrganizationId));
            if (!organizationQueryResult.IsSuccess)
                return Result.Failure<ProjectDetailViewModel>(organizationQueryResult.Errors);

           

            var boardQueryResult = await SendQueryAsync(new GetBoardsByProjectIdQuery(id));
            if (!boardQueryResult.IsSuccess)
                return Result.Failure<ProjectDetailViewModel>(boardQueryResult.Errors);


            var projectReportQueryResult = await SendQueryAsync(new GetProjectReportQuery(id));
            if (!projectReportQueryResult.IsSuccess)
                return Result.Failure<ProjectDetailViewModel>(projectReportQueryResult.Errors);



            var projectDetail = new ProjectDetailViewModel
            {
                Organization = organizationQueryResult.Value,
                Project = projectQueryResult.Value,
                Reports = projectReportQueryResult.Value,
                Boards= boardQueryResult.Value,
            };

            return Result.Success(projectDetail);

        }



        #endregion

    }
}
