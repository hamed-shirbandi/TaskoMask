using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Queries;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Application.Workspace.Owners.Queries.Models;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.Helpers;
using System.Collections.Generic;
using TaskoMask.Domain.Workspace.Organizations.Data;
using TaskoMask.Domain.Workspace.Owners.Data;
using TaskoMask.Domain.Authorization.Data;
using TaskoMask.Application.Share.Dtos.Authorization.Users;

namespace TaskoMask.Application.Workspace.Owners.Queries.Handlers
{
    public class OwnerQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetOwnerByIdQuery, OwnerBasicInfoDto>,
        IRequestHandler<SearchOwnersQuery, PaginatedListReturnType<OwnerOutputDto>>
    {
        #region Fields

        private readonly IOwnerAggregateRepository _ownerRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUserRepository _userRepository;

        #endregion

        #region Ctors

        public OwnerQueryHandlers(IOwnerAggregateRepository ownerRepository, IDomainNotificationHandler notifications, IMapper mapper,  IOrganizationRepository organizationRepository, IUserRepository userRepository) : base(mapper, notifications)
        {
            _ownerRepository = ownerRepository;
            _organizationRepository = organizationRepository;
            _userRepository = userRepository;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<OwnerBasicInfoDto> Handle(GetOwnerByIdQuery request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetByIdAsync(request.Id);
            if (owner == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Owner);

            var ownerDto = _mapper.Map<OwnerBasicInfoDto>(owner);

            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.User);

            //add authentication info from user ti operator
            ownerDto.UserInfo = _mapper.Map<UserBasicInfoDto>(user);

            return ownerDto;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<PaginatedListReturnType<OwnerOutputDto>> Handle(SearchOwnersQuery request, CancellationToken cancellationToken)
        {
            var owners = _ownerRepository.Search(request.Page, request.RecordsPerPage, request.Term, out var pageNumber, out var totalCount);
            var ownersDto = _mapper.Map<IEnumerable<OwnerOutputDto>>(owners);

            foreach (var item in ownersDto)
            {
                //add authentication info from user ti operator
                var user = await _userRepository.GetByIdAsync(item.Id);
                if (user != null)
                    item.UserInfo = _mapper.Map<UserBasicInfoDto>(user);


                //As an invited owner to organizations
                //item.OrganizationsCount = await _invitationRepository.OrganizationsCountByInvitedOwnerIdAsync(item.Id);

                //As an owner of organizations
                item.OrganizationsCount += await _organizationRepository.CountByOwnerOwnerIdAsync(item.Id);
            }


            return new PaginatedListReturnType<OwnerOutputDto>
            {
                TotalCount = totalCount,
                PageNumber = pageNumber,
                Items = ownersDto
            };
        }



        #endregion

        #region Private Methods




        #endregion
    }
}
