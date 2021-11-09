using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Team.Members.Queries.Models;
using TaskoMask.Application.Core.Dtos.Team.Members;
using TaskoMask.Domain.Team.Data;
using TaskoMask.Application.Core.Helpers;
using System.Collections.Generic;

namespace TaskoMask.Application.Team.Members.Queries.Handlers
{
    public class MemberQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetMemberByIdQuery, MemberBasicInfoDto>,
        IRequestHandler<SearchMembersQuery, PublicPaginatedListReturnType<MemberOutputDto>>
    {
        #region Fields

        private readonly IMemberRepository _memberRepository;
        private readonly IInvitationRepository _invitationRepository;
        private readonly IOrganizationRepository _organizationRepository;

        #endregion

        #region Ctors

        public MemberQueryHandlers(IMemberRepository memberRepository, IDomainNotificationHandler notifications, IMapper mapper, IInvitationRepository invitationRepository, IOrganizationRepository organizationRepository) : base(mapper, notifications)
        {
            _memberRepository = memberRepository;
            _invitationRepository = invitationRepository;
            _organizationRepository = organizationRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<MemberBasicInfoDto> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetByIdAsync(request.Id);
            if (member == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Member);

            return _mapper.Map<MemberBasicInfoDto>(member);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<PublicPaginatedListReturnType<MemberOutputDto>> Handle(SearchMembersQuery request, CancellationToken cancellationToken)
        {
            var members =  _memberRepository.Search(request.Page,request.RecordsPerPage,request.Term, out var pageNumber, out var totalCount);
            var membersDto = _mapper.Map<IEnumerable<MemberOutputDto>>(members);

            foreach (var item in membersDto)
            {
                //As an invited member to organizations
                item.OrganizationsCount = await _invitationRepository.OrganizationsCountByInvitedMemberIdAsync(item.Id);

                //As an owner of organizations
                item.OrganizationsCount += await _organizationRepository.CountByOwnerMemberIdAsync(item.Id);
            }


            return new PublicPaginatedListReturnType<MemberOutputDto>
            { 
                 TotalCount = totalCount,
                PageNumber = pageNumber,
                Items = membersDto
            };
        }



        #endregion

        #region Private Methods




        #endregion
    }
}
