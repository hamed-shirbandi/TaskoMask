using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Projects;
using TaskoMask.Application.Queries.Models.Organizations;
using TaskoMask.Application.Queries.Models.Projects;
using TaskoMask.Application.Services.Projects.Dto;
using TaskoMask.Application.ViewMoldes;

namespace TaskoMask.Application.Services.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProjectService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }



        public async Task<Result> CreateAsync(ProjectInput input)
        {
            var project = _mapper.Map<CreateProjectCommand>(input);

            return await _mediator.Send(project);
        }


        public async Task<ProjectListViewModel> GetListByOrganizationIdAsync(string organizationId)
        {
            var projectsQuery = new GetProjectsByOrganizationIdQuery(organizationId: organizationId);
            var projects= await _mediator.Send(projectsQuery);

            var organizationQuery = new GetOrganizationByIdQuery(id: organizationId);
            var organization = await _mediator.Send(organizationQuery);

            return new ProjectListViewModel
            {
                Organization= organization,
                Projects = projects,
            };
        }


        public async Task<long> CountAsync()
        {
            var query = new GetProjectsCountQuery();
            return  await _mediator.Send(query);
        }

       
    }
}
