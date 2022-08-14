using AutoMapper;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Workspace.Organizations.Commands.Models;
using TaskoMask.Services.Monolith.Application.Workspace.Organizations.Queries.Models;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Services.Monolith.Application.Core.Notifications;
using TaskoMask.Services.Monolith.Application.Share.ViewModels;
using TaskoMask.Services.Monolith.Application.Workspace.Projects.Queries.Models;
using System.Linq;
using TaskoMask.Services.Monolith.Application.Core.Bus;
using TaskoMask.Services.Monolith.Application.Core.Services.Application;
using TaskoMask.Services.Monolith.Application.Workspace.Boards.Queries.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Organizations.Services
{
    public class OrganizationService : ApplicationService, IOrganizationService
    {
        #region Fields

        #endregion

        #region Ctors

        public OrganizationService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications ) : base(inMemoryBus, mapper, notifications)
        {
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> AddAsync(AddOrganizationDto input)
        {
            var cmd = new AddOrganizationCommand(ownerId: input.OwnerId, name: input.Name, description: input.Description);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(UpdateOrganizationDto input)
        {
            var cmd = new UpdateOrganizationCommand(id: input.Id, name: input.Name, description: input.Description);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OrganizationDetailsViewModel>> GetDetailsAsync(string id)
        {
            var organizationQueryResult = await GetByIdAsync(id);
            if (!organizationQueryResult.IsSuccess)
                return Result.Failure<OrganizationDetailsViewModel>(organizationQueryResult.Errors);


            var projectsQueryResult = await SendQueryAsync(new GetProjectsByOrganizationIdQuery(id));
            if (!projectsQueryResult.IsSuccess)
                return Result.Failure<OrganizationDetailsViewModel>(projectsQueryResult.Errors);


            var projectsId = projectsQueryResult.Value.Select(p => p.Id).ToArray();
            var boardsQueryResult = await SendQueryAsync(new GetBoardsByProjectsIdQuery(projectsId));
            if (!boardsQueryResult.IsSuccess)
                return Result.Failure<OrganizationDetailsViewModel>(boardsQueryResult.Errors);


            var boardsId = boardsQueryResult.Value.Select(p => p.Id).ToArray();
            var organizationReportQueryResult = await SendQueryAsync(new GetOrganizationReportQuery(id, projectsId, boardsId));
            if (!organizationReportQueryResult.IsSuccess)
                return Result.Failure<OrganizationDetailsViewModel>(organizationReportQueryResult.Errors);

            var organizationDetail = new OrganizationDetailsViewModel
            {
                Organization = organizationQueryResult.Value,
                Projects = projectsQueryResult.Value,
                Boards = boardsQueryResult.Value,
                Reports = organizationReportQueryResult.Value,
            };

            return Result.Success(organizationDetail);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<OrganizationDetailsViewModel>>> GetListWithDetailsByOwnerIdAsync(string ownerId)
        {
            var organizationQueryResult = await GetListByOwnerIdAsync(ownerId);
            if (!organizationQueryResult.IsSuccess)
                return Result.Failure<IEnumerable<OrganizationDetailsViewModel>>(organizationQueryResult.Errors);

            var organizationsDetail = new List<OrganizationDetailsViewModel>();

            foreach (var organization in organizationQueryResult.Value)
            {
                var organizationDetailResult = await GetDetailsAsync(organization.Id);
                if (!organizationDetailResult.IsSuccess)
                    return Result.Failure<IEnumerable<OrganizationDetailsViewModel>>(organizationDetailResult.Errors);

                organizationsDetail.Add(organizationDetailResult.Value);
            }

            return Result.Success(organizationsDetail.AsEnumerable());
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OrganizationBasicInfoDto>> GetByIdAsync(string id)
        {
            return await SendQueryAsync(new GetOrganizationByIdQuery(id));
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<OrganizationBasicInfoDto>>> GetListByOwnerIdAsync(string ownerId)
        {
            return await SendQueryAsync(new GetOrganizationsByOwnerIdQuery(ownerId));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<PaginatedListReturnType<OrganizationOutputDto>>> SearchAsync(int page, int recordsPerPage, string term)
        {
            return await SendQueryAsync(new SearchOrganizationsQuery(page, recordsPerPage, term));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<IEnumerable<SelectListItem>>> GetSelectListAsync(string ownerId)
        {
            var organizationQueryResult = await GetListByOwnerIdAsync(ownerId);
            if (!organizationQueryResult.IsSuccess)
                return Result.Failure<IEnumerable<SelectListItem>>(organizationQueryResult.Errors);

            var organizations = organizationQueryResult.Value.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id,

            }).AsEnumerable();

            return Result.Success(organizations);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<long>> CountAsync()
        {
            return await SendQueryAsync(new GetOrganizationsCountQuery());
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> DeleteAsync(string id)
        {
            var cmd = new DeleteOrganizationCommand(id);
            return await SendCommandAsync(cmd);
        }



        #endregion

        #region Private Methods


        #endregion
    }
}
