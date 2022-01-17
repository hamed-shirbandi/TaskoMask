using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Workspace.Organizations.Queries.Models;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Domain.Workspace.Organizations.Data;
using TaskoMask.Domain.Workspace.Owners.Data;

namespace TaskoMask.Application.Workspace.Organizations.Queries.Handlers
{
    public class OrganizationQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetOrganizationByIdQuery, OrganizationBasicInfoDto>,
        IRequestHandler<GetOrganizationReportQuery, OrganizationReportDto>,
        IRequestHandler<GetOrganizationsByOwnerOwnerIdQuery, IEnumerable<OrganizationBasicInfoDto>>,
        IRequestHandler<SearchOrganizationsQuery, PaginatedListReturnType<OrganizationOutputDto>>
    {
        #region Fields

        private readonly IOrganizationRepository _organizationRepository;
        private readonly IOwnerAggregateRepository _ownerRepository;
        private readonly IProjectRepository _projectRepository;

        #endregion

        #region Ctors

        public OrganizationQueryHandlers(IOrganizationRepository organizationRepository, IDomainNotificationHandler notifications, IMapper mapper, IOwnerAggregateRepository ownerRepository, IProjectRepository projectRepository) : base(mapper, notifications)
        {
            _organizationRepository = organizationRepository;
            _ownerRepository = ownerRepository;
            _projectRepository = projectRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<OrganizationBasicInfoDto> Handle(GetOrganizationByIdQuery request, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetByIdAsync(request.Id);
            if (organization == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Organization);

            return _mapper.Map<OrganizationBasicInfoDto>(organization);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<OrganizationBasicInfoDto>> Handle(GetOrganizationsByOwnerOwnerIdQuery request, CancellationToken cancellationToken)
        {
            var organizations = await _organizationRepository.GetListByOwnerOwnerIdAsync(request.OwnerOwnerId);
            return _mapper.Map<IEnumerable<OrganizationBasicInfoDto>>(organizations);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<OrganizationReportDto> Handle(GetOrganizationReportQuery request, CancellationToken cancellationToken)
        {
            //TODO Implement GetOrganizationReportQuery
            return new OrganizationReportDto();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<PaginatedListReturnType<OrganizationOutputDto>> Handle(SearchOrganizationsQuery request, CancellationToken cancellationToken)
        {
            var organizations = _organizationRepository.Search(request.Page, request.RecordsPerPage, request.Term, out var pageNumber, out var totalCount);
            var organizationsDto = _mapper.Map<IEnumerable<OrganizationOutputDto>>(organizations);

            foreach (var item in organizationsDto)
            {
                var owner = await _ownerRepository.GetByIdAsync(item.OwnerOwnerId);
                item.OwnerOwnerDisplayName = owner?.DisplayName.Value;
                item.ProjectsCount =await _projectRepository.CountByOrganizationIdAsync(item.Id);
            }

            return new PaginatedListReturnType<OrganizationOutputDto>
            {
                TotalCount = totalCount,
                PageNumber = pageNumber,
                Items = organizationsDto
            };
        }


        #endregion

    }
}
