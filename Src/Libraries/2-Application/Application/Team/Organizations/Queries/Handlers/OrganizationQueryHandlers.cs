using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Team.Organizations.Queries.Models;
using TaskoMask.Application.Share.Dtos.Team.Organizations;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Team.Data;
using TaskoMask.Application.Share.Helpers;

namespace TaskoMask.Application.Team.Organizations.Queries.Handlers
{
    public class OrganizationQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetOrganizationByIdQuery, OrganizationBasicInfoDto>,
        IRequestHandler<GetOrganizationReportQuery, OrganizationReportDto>,
        IRequestHandler<GetOrganizationsByOwnerMemberIdQuery, IEnumerable<OrganizationBasicInfoDto>>,
        IRequestHandler<SearchOrganizationsQuery, PaginatedListReturnType<OrganizationOutputDto>>
    {
        #region Fields

        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IProjectRepository _projectRepository;

        #endregion

        #region Ctors

        public OrganizationQueryHandlers(IOrganizationRepository organizationRepository, IDomainNotificationHandler notifications, IMapper mapper, IMemberRepository memberRepository, IProjectRepository projectRepository) : base(mapper, notifications)
        {
            _organizationRepository = organizationRepository;
            _memberRepository = memberRepository;
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
        public async Task<IEnumerable<OrganizationBasicInfoDto>> Handle(GetOrganizationsByOwnerMemberIdQuery request, CancellationToken cancellationToken)
        {
            var organizations = await _organizationRepository.GetListByOwnerMemberIdAsync(request.OwnerMemberId);
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
                var member = await _memberRepository.GetByIdAsync(item.OwnerMemberId);
                item.OwnerMemberDisplayName = member?.DisplayName;
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
