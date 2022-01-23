using AutoMapper;
using TaskoMask.Application.Share.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Organizations.Commands.Models;
using TaskoMask.Application.Workspace.Organizations.Queries.Models;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Application.Workspace.Projects.Queries.Models;
using System.Linq;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Core.Services;
using TaskoMask.Application.Workspace.Boards.Queries.Models;
using TaskoMask.Application.Workspace.Tasks.Queries.Models;

namespace TaskoMask.Application.Workspace.Organizations.Services
{
    public class OrganizationService : ApplicationService, IOrganizationService
    {
        #region Fields

        #endregion

        #region Ctors

        public OrganizationService(IInMemoryBus inMemoryBus, IMapper mapper, IDomainNotificationHandler notifications) : base(inMemoryBus, mapper, notifications)
        { }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(OrganizationUpsertDto input)
        {
            var cmd = new CreateOrganizationCommand(ownerId: input.OwnerId, name: input.Name, description: input.Description);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(OrganizationUpsertDto input)
        {
            var cmd = new UpdateOrganizationCommand(id: input.Id, name: input.Name, description: input.Description);
            return await SendCommandAsync(cmd);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OrganizationDetailsViewModel>> GetDetailsAsync(string id)
        {
            var organizationQueryResult = await SendQueryAsync(new GetOrganizationByIdQuery(id));
            if (!organizationQueryResult.IsSuccess)
                return Result.Failure<OrganizationDetailsViewModel>(organizationQueryResult.Errors);


            var projectQueryResult = await SendQueryAsync(new GetProjectsByOrganizationIdQuery(id));
            if (!projectQueryResult.IsSuccess)
                return Result.Failure<OrganizationDetailsViewModel>(projectQueryResult.Errors);


            var organizationReportQueryResult = await SendQueryAsync(new GetOrganizationReportQuery(id));
            if (!organizationReportQueryResult.IsSuccess)
                return Result.Failure<OrganizationDetailsViewModel>(organizationReportQueryResult.Errors);


            var boardQueryResult = await SendQueryAsync(new GetBoardsByOrganizationIdQuery(id));
            if (!boardQueryResult.IsSuccess)
                return Result.Failure<OrganizationDetailsViewModel>(boardQueryResult.Errors);


            var taskQueryResult = await SendQueryAsync(new GetTasksByOrganizationIdQuery(id, takeCount: 20));
            if (!taskQueryResult.IsSuccess)
                return Result.Failure<OrganizationDetailsViewModel>(taskQueryResult.Errors);

            var organizationDetail = new OrganizationDetailsViewModel
            {
                Organization = organizationQueryResult.Value,
                Projects = projectQueryResult.Value,
                Boards = boardQueryResult.Value,
                LastTasks = taskQueryResult.Value,
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
        public async Task<Result<OrganizationReportDto>> GetReportAsync(string id)
        {
            return await SendQueryAsync(new GetOrganizationReportQuery(id));
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
            return await SendQueryAsync(new OrganizationsCountQuery());
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
