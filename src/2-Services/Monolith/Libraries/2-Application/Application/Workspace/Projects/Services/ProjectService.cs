using AutoMapper;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Projects.Commands.Models;
using TaskoMask.Services.Monolith.Application.Workspace.Projects.Queries.Models;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Projects;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using System.Collections.Generic;
using TaskoMask.Services.Monolith.Application.Core.Notifications;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Queries.Models;
using TaskoMask.Services.Monolith.Application.Core.Bus;
using TaskoMask.Services.Monolith.Application.Core.Services.Application;
using System.Linq;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Projects.Services
{
    public class ProjectService : ApplicationService, IProjectService
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
        public async Task<Result<CommandResult>> AddAsync(AddProjectDto input)
        {
            var cmd = new AddProjectCommand(organizationId: input.OrganizationId, name: input.Name, description: input.Description);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(UpdateProjectDto input)
        {
            var cmd = new UpdateProjectCommand(id: input.Id, name: input.Name, description: input.Description);
            return await SendCommandAsync(cmd);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<ProjectOutputDto>> GetByIdAsync(string id)
        {
            return await SendQueryAsync(new GetProjectByIdQuery(id));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<ProjectDetailsViewModel>> GetDetailsAsync(string id)
        {
            var projectQueryResult = await GetByIdAsync(id);
            if (!projectQueryResult.IsSuccess)
                return Result.Failure<ProjectDetailsViewModel>(projectQueryResult.Errors);

            var boardsQueryResult = await SendQueryAsync(new GetBoardsByProjectIdQuery(id));
            if (!boardsQueryResult.IsSuccess)
                return Result.Failure<ProjectDetailsViewModel>(boardsQueryResult.Errors);


            var boardDetail = new ProjectDetailsViewModel
            {
                Project = projectQueryResult.Value,
                Boards = boardsQueryResult.Value,
            };

            return Result.Success(boardDetail);

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
        public async Task<Result<PaginatedList<ProjectOutputDto>>> SearchAsync(int page, int recordsPerPage, string term)
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



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<long>> CountAsync()
        {
            return await SendQueryAsync(new GetProjectsCountQuery());
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var cmd = new DeleteProjectCommand(id);
            return await SendCommandAsync(cmd);
        }


        #endregion
    }
}
