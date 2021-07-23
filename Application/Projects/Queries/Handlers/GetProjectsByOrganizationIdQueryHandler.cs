using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Projects.Queries.Models;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Projects.Queries.Handlers
{
    public class GetProjectsByOrganizationIdQueryHandler : IRequestHandler<GetProjectsByOrganizationIdQuery, IEnumerable<ProjectOutput>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public GetProjectsByOrganizationIdQueryHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectOutput>> Handle(GetProjectsByOrganizationIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetListByOrganizationIdAsync(request.OrganizationId);
            return _mapper.Map<IEnumerable<ProjectOutput>>(projects);
        }
    }
}
