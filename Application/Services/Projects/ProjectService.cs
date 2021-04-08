using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Projects;
using TaskoMask.Application.Queries.Models.Organizations;
using TaskoMask.Application.Queries.Models.Projects;
using TaskoMask.Application.Services.Projects.Dto;
using TaskoMask.Application.ViewMoldes;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Services.Projects
{
    public class ProjectService : BaseApplicationService, IProjectService
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

            return await _mediator.Send(project);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateAsync(ProjectInput input)
        {
            var updateCommand = _mapper.Map<UpdateProjectCommand>(input);
            return await _mediator.Send(updateCommand);
        }


        #endregion

        #region Query Services


        /// <summary>
        /// 
        /// </summary>
        public async Task<ProjectOutput> GetByIdAsync(string id)
        {
            var query = new GetProjectByIdQuery(id);
            return await _mediator.Send(query);
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
            var projects = await _mediator.Send(projectsQuery);

            var organizationQuery = new GetOrganizationByIdQuery(id: organizationId);
            var organization = await _mediator.Send(organizationQuery);

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
            return await _mediator.Send(query);
        }


        #endregion

    }
}
