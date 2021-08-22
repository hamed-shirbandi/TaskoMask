using AutoMapper;
using TaskoMask.Domain.Core.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Projects.Commands.Models;
using TaskoMask.Application.Organizations.Queries.Models;
using TaskoMask.Application.Projects.Queries.Models;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Application.Core.ViewModels;
using TaskoMask.Application.Core.Commands;
using System.Collections.Generic;
using TaskoMask.Application.BaseEntities.Services;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Boards.Queries.Models;
using TaskoMask.Application.Core.Bus;

namespace TaskoMask.Application.Projects.Services
{
    public class ProjectService : BaseEntityService<Project>, IProjectService
    {
        #region Fields


        #endregion

        #region Ctors

        public ProjectService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        { }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(ProjectInputDto input)
        {
            var cmd = new CreateProjectCommand(organizationId: input.OrganizationId, name: input.Name, description: input.Description);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(ProjectInputDto input)
        {
            var cmd = new UpdateProjectCommand(id: input.Id, name: input.Name, description: input.Description);
            return await SendCommandAsync(cmd);
        }



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



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<ProjectBasicInfoDto>> GetByIdAsync(string id)
        {
            return await SendQueryAsync(new GetProjectByIdQuery(id));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<ProjectBasicInfoDto>>> GetListByOrganizationIdAsync(string organizationId)
        {
            return await SendQueryAsync(new GetProjectsByOrganizationIdQuery(organizationId));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<ProjectReportDto>> GetReportAsync(string id)
        {
            return await SendQueryAsync(new GetProjectReportQuery(id));
        }



        #endregion
    }
}
