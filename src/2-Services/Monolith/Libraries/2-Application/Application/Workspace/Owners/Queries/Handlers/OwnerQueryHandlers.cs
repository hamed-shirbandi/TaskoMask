using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Core.Queries;
using TaskoMask.Services.Monolith.Application.Share.Resources;
using TaskoMask.Services.Monolith.Application.Core.Exceptions;
using TaskoMask.Services.Monolith.Domain.Share.Resources;
using TaskoMask.Services.Monolith.Application.Core.Notifications;
using TaskoMask.Services.Monolith.Application.Workspace.Owners.Queries.Models;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Services.Monolith.Application.Share.Helpers;
using System.Collections.Generic;
using TaskoMask.Services.Monolith.Domain.DomainModel.Authorization.Data;
using TaskoMask.Services.Monolith.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;

namespace TaskoMask.Services.Monolith.Application.Workspace.Owners.Queries.Handlers
{
    public class OwnerQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetOwnerByIdQuery, OwnerBasicInfoDto>,
        IRequestHandler<GetOwnerByUserNameQuery, OwnerBasicInfoDto>,
        IRequestHandler<SearchOwnersQuery, PaginatedListReturnType<OwnerOutputDto>>,
        IRequestHandler<GetOwnersCountQuery, long>

    {
        #region Fields

        private readonly IOwnerRepository _ownerRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUserRepository _userRepository;

        #endregion

        #region Ctors

        public OwnerQueryHandlers(IOwnerRepository ownerRepository, IDomainNotificationHandler notifications, IMapper mapper,  IOrganizationRepository organizationRepository, IUserRepository userRepository) : base(mapper, notifications)
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
        public async Task<OwnerBasicInfoDto> Handle(GetOwnerByUserNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserNameAsync(request.UserName);
            if (user == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.User);


            var owner = await _ownerRepository.GetByIdAsync(user.Id);
            if (owner == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Owner);

            var ownerDto = _mapper.Map<OwnerBasicInfoDto>(owner);

          
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


                //TODO Get OrganizationsCount as an member 
                //As an owner of organizations
                item.OrganizationsCount += await _organizationRepository.CountByOwnerIdAsync(item.Id);
            }


            return new PaginatedListReturnType<OwnerOutputDto>
            {
                TotalCount = totalCount,
                PageNumber = pageNumber,
                Items = ownersDto
            };
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<long> Handle(GetOwnersCountQuery request, CancellationToken cancellationToken)
        {
            return await _ownerRepository.CountAsync();
        }




        #endregion

        #region Private Methods




        #endregion
    }
}
