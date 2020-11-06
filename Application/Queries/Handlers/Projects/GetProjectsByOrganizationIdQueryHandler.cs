using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Queries.Models.Projects;
using TaskoMask.Application.Services.Projects.Dto;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Queries.Handlers.Projects
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
