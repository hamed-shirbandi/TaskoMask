using AutoMapper;
using MediatR;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Owners;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Owners.Read.Api.Features.Owners.GetOwnerById
{
    public class GetOwnerByIdHandler : BaseQueryHandler, IRequestHandler<GetOwnerByIdRequest, GetOwnerDto>
    {
        #region Fields

        private readonly OwnerReadDbContext _ownerReadDbContext;

        #endregion

        #region Ctors

        public GetOwnerByIdHandler(OwnerReadDbContext ownerReadDbContext, IMapper mapper) : base(mapper)
        {
            _ownerReadDbContext = ownerReadDbContext;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<GetOwnerDto> Handle(GetOwnerByIdRequest request, CancellationToken cancellationToken)
        {
            var owner = await _ownerReadDbContext.Owners.Find(e => e.Id == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (owner == null)
                throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            return _mapper.Map<GetOwnerDto>(owner);
        }



        #endregion

        #region Private Methods




        #endregion
    }
}
