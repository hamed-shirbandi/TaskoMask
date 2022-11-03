using TaskoMask.BuildingBlocks.Contracts.Helpers;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Projects.Commands.Models;
using TaskoMask.Services.Monolith.Application.Workspace.Projects.Queries.Models;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using System.Collections.Generic;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Queries.Models;
using TaskoMask.BuildingBlocks.Application.Bus;
using System.Linq;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Application.Services;

namespace TaskoMask.Services.Monolith.Application.Workspace.Projects.Services
{
    public class ProjectService : ApplicationService, IProjectService
    {
        #region Fields


        #endregion

        #region Ctors

        public ProjectService(IInMemoryBus inMemoryBus) : base(inMemoryBus)
        { }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> AddAsync(AddProjectDto input)
        {
            var cmd = new AddProjectCommand(organizationId: input.OrganizationId, name: input.Name, description: input.Description);
            return await _inMemoryBus.SendCommand(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(UpdateProjectDto input)
        {
            var cmd = new UpdateProjectCommand(id: input.Id, name: input.Name, description: input.Description);
            return await _inMemoryBus.SendCommand(cmd);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<ProjectOutputDto>> GetByIdAsync(string id)
        {
            return await _inMemoryBus.SendQuery(new GetProjectByIdQuery(id));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<ProjectDetailsViewModel>> GetDetailsAsync(string id)
        {
            var projectQueryResult = await GetByIdAsync(id);
            if (!projectQueryResult.IsSuccess)
                return Result.Failure<ProjectDetailsViewModel>(projectQueryResult.Errors);

            var boardsQueryResult = await _inMemoryBus.SendQuery(new GetBoardsByProjectIdQuery(id));
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
            return await _inMemoryBus.SendQuery(new GetProjectsByOrganizationIdQuery(organizationId));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<PaginatedList<ProjectOutputDto>>> SearchAsync(int page, int recordsPerPage, string term)
        {
            return await _inMemoryBus.SendQuery(new SearchProjectsQuery(page, recordsPerPage, term));
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
            return await _inMemoryBus.SendQuery(new GetProjectsCountQuery());
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var cmd = new DeleteProjectCommand(id);
            return await _inMemoryBus.SendCommand(cmd);
        }


        #endregion
    }
}
