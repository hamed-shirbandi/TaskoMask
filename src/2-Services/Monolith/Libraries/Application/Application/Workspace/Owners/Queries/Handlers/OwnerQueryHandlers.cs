using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.Services.Monolith.Application.Workspace.Owners.Queries.Models;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Owners;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.BuildingBlocks.Contracts.Models;

namespace TaskoMask.Services.Monolith.Application.Workspace.Owners.Queries.Handlers
{
    public class OwnerQueryHandlers : BaseQueryHandler,
        IRequestHandler<GetOwnerByIdQuery, OwnerBasicInfoDto>,
        IRequestHandler<GetOwnerByEmailQuery, OwnerBasicInfoDto>,
        IRequestHandler<SearchOwnersQuery, PaginatedList<OwnerOutputDto>>,
        IRequestHandler<GetOwnersCountQuery, long>

    {
        #region Fields

        private readonly IOwnerRepository _ownerRepository;
        private readonly IOrganizationRepository _organizationRepository;

        #endregion

        #region Ctors

        public OwnerQueryHandlers(IOwnerRepository ownerRepository, INotificationHandler notifications, IMapper mapper,  IOrganizationRepository organizationRepository) : base(mapper, notifications)
        {
            _ownerRepository = ownerRepository;
            _organizationRepository = organizationRepository;
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
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            var ownerDto = _mapper.Map<OwnerBasicInfoDto>(owner);

            return ownerDto;

        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<OwnerBasicInfoDto> Handle(GetOwnerByEmailQuery request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetByEmailAsync(request.Email);
            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            var ownerDto = _mapper.Map<OwnerBasicInfoDto>(owner);

            return ownerDto;

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<PaginatedList<OwnerOutputDto>> Handle(SearchOwnersQuery request, CancellationToken cancellationToken)
        {
            var owners = _ownerRepository.Search(request.Page, request.RecordsPerPage, request.Term, out var pageNumber, out var totalCount);
            var ownersDto = _mapper.Map<IEnumerable<OwnerOutputDto>>(owners);

            foreach (var item in ownersDto)
                item.OrganizationsCount += await _organizationRepository.CountByOwnerIdAsync(item.Id);


            return new PaginatedList<OwnerOutputDto>
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
