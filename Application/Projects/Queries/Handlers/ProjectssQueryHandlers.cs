using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Projects.Queries.Models;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Domain.Data;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Projects.Queries.Handlers
{
    public class ProjectssQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetProjectByIdQuery, ProjectOutput>,
        IRequestHandler<GetProjectsByOrganizationIdQuery, IEnumerable<ProjectOutput>>
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectssQueryHandlers(IProjectRepository projectRepository, IMapper mapper, IMediator mediator) : base(mediator, mapper)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectOutput>> Handle(GetProjectsByOrganizationIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetListByOrganizationIdAsync(request.OrganizationId);
            return _mapper.Map<IEnumerable<ProjectOutput>>(projects);
        }

        public async Task<ProjectOutput> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            return _mapper.Map<ProjectOutput>(project);
        }
    }
}
