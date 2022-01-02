using AutoMapper;
using TaskoMask.Application.Share.Helpers;
using System.Threading.Tasks;
using TaskoMask.Application.Team.Projects.Commands.Models;
using TaskoMask.Application.Team.Organizations.Queries.Models;
using TaskoMask.Application.Team.Projects.Queries.Models;
using TaskoMask.Application.Share.Dtos.Team.Projects;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Application.Core.Commands;
using System.Collections.Generic;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Workspace.Boards.Queries.Models;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Common.Base.Services;
using TaskoMask.Domain.Team.Entities;
using System.Linq;

namespace TaskoMask.Application.Team.Projects.Services
{
    public class ProjectService : BaseService<Project>, IProjectService
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
        public async Task<Result<CommandResult>> CreateAsync(ProjectUpsertDto input)
        {
            var cmd = new CreateProjectCommand(organizationId: input.OrganizationId, name: input.Name, description: input.Description);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(ProjectUpsertDto input)
        {
            var cmd = new UpdateProjectCommand(id: input.Id, name: input.Name, description: input.Description);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<ProjectDetailsViewModel>> GetDetailsAsync(string id)
        {
            var projectQueryResult = await SendQueryAsync(new GetProjectByIdQuery(id));
            if (!projectQueryResult.IsSuccess)
                return Result.Failure<ProjectDetailsViewModel>(projectQueryResult.Errors);


            var organizationQueryResult = await SendQueryAsync(new GetOrganizationByIdQuery(projectQueryResult.Value.OrganizationId));
            if (!organizationQueryResult.IsSuccess)
                return Result.Failure<ProjectDetailsViewModel>(organizationQueryResult.Errors);



            var boardQueryResult = await SendQueryAsync(new GetBoardsByProjectIdQuery(id));
            if (!boardQueryResult.IsSuccess)
                return Result.Failure<ProjectDetailsViewModel>(boardQueryResult.Errors);


            var projectReportQueryResult = await SendQueryAsync(new GetProjectReportQuery(id));
            if (!projectReportQueryResult.IsSuccess)
                return Result.Failure<ProjectDetailsViewModel>(projectReportQueryResult.Errors);



            var projectDetail = new ProjectDetailsViewModel
            {
                Organization = organizationQueryResult.Value,
                Project = projectQueryResult.Value,
                Reports = projectReportQueryResult.Value,
                Boards = boardQueryResult.Value,
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



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<PaginatedListReturnType<ProjectOutputDto>>> SearchAsync(int page, int recordsPerPage, string term)
        {
            return await SendQueryAsync(new SearchProjectsQuery(page, recordsPerPage, term));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<SelectListItem>>> GetSelectListAsync(string organizationId)
        {
            var projectQueryResult = await GetListByOrganizationIdAsync(organizationId);
            if (!projectQueryResult.IsSuccess)
                return Result.Failure<IEnumerable<SelectListItem>>(projectQueryResult.Errors);

            var projects = projectQueryResult.Value.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id,

            }).AsEnumerable();

            return Result.Success(projects);

        }

        #endregion
    }
}
