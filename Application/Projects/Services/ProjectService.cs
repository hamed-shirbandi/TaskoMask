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

        #region Command Services


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(ProjectInputDto input)
        {
            var createCommand = _mapper.Map<CreateProjectCommand>(input);

            return await SendCommandAsync(createCommand);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(ProjectInputDto input)
        {
            var updateCommand = _mapper.Map<UpdateProjectCommand>(input);
            return await SendCommandAsync(updateCommand);
        }


        #endregion

        #region Query Services


        /// <summary>
        /// 
        /// </summary>
        public async Task<ProjectOutputDto> GetByIdAsync(string id)
        {
            var query = new GetProjectByIdQuery(id);
            return await SendQueryAsync<GetProjectByIdQuery, ProjectOutputDto>(query);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<ProjectInputDto> GetByIdToUpdateAsync(string id)
        {
            var organization = await GetByIdAsync(id);
            return _mapper.Map<ProjectInputDto>(organization);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<ProjectListViewModel> GetListByOrganizationIdAsync(string organizationId)
        {
            var projectsQuery = new GetProjectsByOrganizationIdQuery(organizationId: organizationId);
            var projects = await SendQueryAsync<GetProjectsByOrganizationIdQuery, IEnumerable<ProjectOutputDto>>(projectsQuery);

            var organizationQuery = new GetOrganizationByIdQuery(id: organizationId);
            var organization = await SendQueryAsync<GetOrganizationByIdQuery, OrganizationOutputDto>(organizationQuery);

            return new ProjectListViewModel
            {
                Organization = organization,
                Projects = projects,
            };
        }




        #endregion

    }
}
