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
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Core.Notifications;

namespace TaskoMask.Application.Projects.Queries.Handlers
{
    public class ProjectsQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetProjectByIdQuery, ProjectBasicInfoDto>,
        IRequestHandler<GetProjectReportQuery, ProjectReportDto>,
        IRequestHandler<GetProjectsByOrganizationIdQuery, IEnumerable<ProjectBasicInfoDto>>
    {
        #region Fields

        private readonly IProjectRepository _projectRepository;

        #endregion

        #region Ctors

        public ProjectsQueryHandlers(IProjectRepository projectRepository, IDomainNotificationHandler notifications, IMapper mapper) : base(mapper, notifications)
        {
            _projectRepository = projectRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<ProjectBasicInfoDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);
            if (project == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Project);

            return _mapper.Map<ProjectBasicInfoDto>(project);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<ProjectBasicInfoDto>> Handle(GetProjectsByOrganizationIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetListByOrganizationIdAsync(request.OrganizationId);
            return _mapper.Map<IEnumerable<ProjectBasicInfoDto>>(projects);
        }



        /// <summary>
        /// 
        /// </summary>
        public Task<ProjectReportDto> Handle(GetProjectReportQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }


        #endregion

    }
}
