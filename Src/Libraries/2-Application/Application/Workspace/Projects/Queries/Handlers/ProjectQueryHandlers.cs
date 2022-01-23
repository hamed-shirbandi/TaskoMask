using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Projects.Queries.Models;
using TaskoMask.Application.Share.Dtos.Workspace.Projects;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.ReadModel.Data;

namespace TaskoMask.Application.Workspace.Projects.Queries.Handlers
{
    public class ProjectQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetProjectByIdQuery, ProjectBasicInfoDto>,
        IRequestHandler<GetProjectReportQuery, ProjectReportDto>,
        IRequestHandler<GetProjectsByOrganizationIdQuery, IEnumerable<ProjectBasicInfoDto>>,
        IRequestHandler<SearchProjectsQuery, PaginatedListReturnType<ProjectOutputDto>>,
        IRequestHandler<GetProjectsCountQuery, long>

    {
        #region Fields

        private readonly IProjectRepository _projectRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IBoardRepository _boardRepository;

        #endregion

        #region Ctors

        public ProjectQueryHandlers(IProjectRepository projectRepository, IDomainNotificationHandler notifications, IMapper mapper, IBoardRepository boardRepository, IOrganizationRepository organizationRepository) : base(mapper, notifications)
        {
            _projectRepository = projectRepository;
            _boardRepository = boardRepository;
            _organizationRepository = organizationRepository;
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
        public async Task<ProjectReportDto> Handle(GetProjectReportQuery request, CancellationToken cancellationToken)
        {
            //TODO Implement GetProjectReportQuery
            return new ProjectReportDto();
        }





        /// <summary>
        /// 
        /// </summary>
        public async Task<PaginatedListReturnType<ProjectOutputDto>> Handle(SearchProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = _projectRepository.Search(request.Page, request.RecordsPerPage, request.Term, out var pageNumber, out var totalCount);
            var projectsDto = _mapper.Map<IEnumerable<ProjectOutputDto>>(projects);

            foreach (var item in projectsDto)
            {
                var organization = await _organizationRepository.GetByIdAsync(item.OrganizationId);
                item.OrganizationName = organization?.Name;
                item.BoardsCount = await _boardRepository.CountByProjectIdAsync(item.Id) ;
            }

            return new PaginatedListReturnType<ProjectOutputDto>
            {
                TotalCount = totalCount,
                PageNumber = pageNumber,
                Items = projectsDto
            };
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<long> Handle(GetProjectsCountQuery request, CancellationToken cancellationToken)
        {
            return await _projectRepository.CountAsync();
        }



        #endregion

    }
}
