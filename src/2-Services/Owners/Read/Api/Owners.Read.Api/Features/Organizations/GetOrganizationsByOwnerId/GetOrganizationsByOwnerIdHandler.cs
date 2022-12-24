using AutoMapper;
using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationsByOwnerId
{
    public class GetOrganizationsByOwnerIdHandler : BaseQueryHandler, IRequestHandler<GetOrganizationsByOwnerIdRequest, IEnumerable<GetOrganizationDto>>
    {
        #region Fields

        private readonly OwnerReadDbContext _ownerReadDbContext;

        #endregion

        #region Ctors

        public GetOrganizationsByOwnerIdHandler(OwnerReadDbContext ownerReadDbContext, IMapper mapper) : base(mapper)
        {
            _ownerReadDbContext = ownerReadDbContext;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<GetOrganizationDto>> Handle(GetOrganizationsByOwnerIdRequest request, CancellationToken cancellationToken)
        {
            var organizations = await _ownerReadDbContext.Organizations.AsQueryable().Where(o => o.OwnerId == request.OwnerId).ToListAsync();

            return _mapper.Map<IEnumerable<GetOrganizationDto>>(organizations);
        }



        #endregion

        #region Private Methods




        #endregion
    }
}
