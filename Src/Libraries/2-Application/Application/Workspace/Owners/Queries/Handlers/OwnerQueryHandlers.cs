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
using TaskoMask.Domain.WriteModel.Authorization.Data;
using TaskoMask.Application.Share.Dtos.Authorization.Users;
using TaskoMask.Domain.ReadModel.Data;

namespace TaskoMask.Application.Workspace.Owners.Queries.Handlers
{
    public class OwnerQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetOwnerByIdQuery, OwnerBasicInfoDto>,
        IRequestHandler<SearchOwnersQuery, PaginatedListReturnType<OwnerOutputDto>>
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

            return _mapper.Map<OwnerBasicInfoDto>(owner);

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



        #endregion

        #region Private Methods




        #endregion
    }
}
