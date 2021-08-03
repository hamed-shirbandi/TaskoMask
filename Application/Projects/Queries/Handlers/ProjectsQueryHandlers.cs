using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Projects.Queries.Models;
using TaskoMask.Application.Core.Dtos.Projects;
using TaskoMask.Domain.Data;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Entities;

namespace TaskoMask.Application.Projects.Queries.Handlers
{
    public class ProjectsQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetProjectByIdQuery, ProjectBasicInfoDto>,
        IRequestHandler<GetProjectReportQuery, ProjectReportDto>,
        IRequestHandler<GetProjectsByOrganizationIdQuery, IEnumerable<ProjectBasicInfoDto>>
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectsQueryHandlers(IProjectRepository projectRepository, IMapper mapper, IMediator mediator) : base(mediator, mapper)
        {
            _projectRepository = projectRepository;
        }


        public async Task<ProjectBasicInfoDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            if (project == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, typeof(Project));

            return _mapper.Map<ProjectBasicInfoDto>(project);
        }


        public async Task<IEnumerable<ProjectBasicInfoDto>> Handle(GetProjectsByOrganizationIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetListByOrganizationIdAsync(request.OrganizationId);
            return _mapper.Map<IEnumerable<ProjectBasicInfoDto>>(projects);
        }

        public Task<ProjectReportDto> Handle(GetProjectReportQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
