using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Workspace.Members.Queries.Models;
using TaskoMask.Application.Share.Dtos.Workspace.Members;
using TaskoMask.Application.Share.Helpers;
using System.Collections.Generic;
using TaskoMask.Domain.Workspace.Organizations.Data;
using TaskoMask.Domain.Workspace.Members.Data;
using TaskoMask.Domain.Authorization.Data;
using TaskoMask.Application.Share.Dtos.Authorization.Users;

namespace TaskoMask.Application.Workspace.Members.Queries.Handlers
{
    public class MemberQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetMemberByIdQuery, MemberBasicInfoDto>,
        IRequestHandler<SearchMembersQuery, PaginatedListReturnType<MemberOutputDto>>
    {
        #region Fields

        private readonly IMemberRepository _memberRepository;
        private readonly IInvitationRepository _invitationRepository;
        private readonly IOrganizationAggregateRepository _organizationRepository;
        private readonly IUserRepository _userRepository;

        #endregion

        #region Ctors

        public MemberQueryHandlers(IMemberRepository memberRepository, IDomainNotificationHandler notifications, IMapper mapper, IInvitationRepository invitationRepository, IOrganizationAggregateRepository organizationRepository, IUserRepository userRepository) : base(mapper, notifications)
        {
            _memberRepository = memberRepository;
            _invitationRepository = invitationRepository;
            _organizationRepository = organizationRepository;
            _userRepository = userRepository;
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

            var memberDto = _mapper.Map<MemberBasicInfoDto>(member);

            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.User);

            //add authentication info from user ti operator
            memberDto.UserInfo = _mapper.Map<UserBasicInfoDto>(user);

            return memberDto;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<PaginatedListReturnType<MemberOutputDto>> Handle(SearchMembersQuery request, CancellationToken cancellationToken)
        {
            var members = _memberRepository.Search(request.Page, request.RecordsPerPage, request.Term, out var pageNumber, out var totalCount);
            var membersDto = _mapper.Map<IEnumerable<MemberOutputDto>>(members);

            foreach (var item in membersDto)
            {
                //add authentication info from user ti operator
                var user = await _userRepository.GetByIdAsync(item.Id);
                if (user != null)
                    item.UserInfo = _mapper.Map<UserBasicInfoDto>(user);


                //As an invited member to organizations
                item.OrganizationsCount = await _invitationRepository.OrganizationsCountByInvitedMemberIdAsync(item.Id);

                //As an owner of organizations
                item.OrganizationsCount += await _organizationRepository.CountByOwnerMemberIdAsync(item.Id);
            }


            return new PaginatedListReturnType<MemberOutputDto>
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
