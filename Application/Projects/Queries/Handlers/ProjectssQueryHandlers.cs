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
    public class ProjectssQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetProjectByIdQuery, ProjectOutputDto>,
        IRequestHandler<GetProjectsByOrganizationIdQuery, IEnumerable<ProjectOutputDto>>
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectssQueryHandlers(IProjectRepository projectRepository, IMapper mapper, IMediator mediator) : base(mediator, mapper)
        {
            _projectRepository = projectRepository;
        }


        public async Task<ProjectOutputDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            if (project == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, typeof(Project));

            return _mapper.Map<ProjectOutputDto>(project);
        }


        public async Task<IEnumerable<ProjectOutputDto>> Handle(GetProjectsByOrganizationIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetListByOrganizationIdAsync(request.OrganizationId);
            return _mapper.Map<IEnumerable<ProjectOutputDto>>(projects);
        }

       
    }
}
