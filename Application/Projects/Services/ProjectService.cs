using AutoMapper;
using CSharpFunctionalExtensions;
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
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Projects.Services
{
    public class ProjectService : BaseEntityService<Project>, IProjectService
    {

        #region Fields


        #endregion

        #region Ctor

        public ProjectService(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        { }


        #endregion

        #region Command Services


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> CreateAsync(ProjectInput input)
        {
            var project = _mapper.Map<CreateProjectCommand>(input);

            return await SendCommandAsync(project);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(ProjectInput input)
        {
            var updateCommand = _mapper.Map<UpdateProjectCommand>(input);
            return await SendCommandAsync(updateCommand);
        }


        #endregion

        #region Query Services


        /// <summary>
        /// 
        /// </summary>
        public async Task<ProjectOutput> GetByIdAsync(string id)
        {
            var query = new GetProjectByIdQuery(id);
            return await SendQueryAsync<GetProjectByIdQuery, ProjectOutput>(query);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<ProjectInput> GetByIdToUpdateAsync(string id)
        {
            var organization = await GetByIdAsync(id);
            return _mapper.Map<ProjectInput>(organization);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<ProjectListViewModel> GetListByOrganizationIdAsync(string organizationId)
        {
            var projectsQuery = new GetProjectsByOrganizationIdQuery(organizationId: organizationId);
            var projects = await SendQueryAsync<GetProjectsByOrganizationIdQuery, IEnumerable<ProjectOutput>>(projectsQuery);

            var organizationQuery = new GetOrganizationByIdQuery(id: organizationId);
            var organization = await SendQueryAsync<GetOrganizationByIdQuery, OrganizationOutput>(organizationQuery);

            return new ProjectListViewModel
            {
                Organization = organization,
                Projects = projects,
            };
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<long> CountAsync()
        {
            var query = new GetProjectsCountQuery();
            return await SendQueryAsync<GetProjectsCountQuery, long>(query);
        }


        #endregion

    }
}
