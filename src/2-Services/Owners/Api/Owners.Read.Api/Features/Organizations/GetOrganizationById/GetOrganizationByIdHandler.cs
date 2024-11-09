using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationById;

public class GetOrganizationByIdHandler : BaseQueryHandler, IRequestHandler<GetOrganizationByIdRequest, GetOrganizationDto>
{
    #region Fields

    private readonly OwnerReadDbContext _ownerReadDbContext;

    #endregion

    #region Ctors

    public GetOrganizationByIdHandler(OwnerReadDbContext ownerReadDbContext, IMapper mapper)
        : base(mapper)
    {
        _ownerReadDbContext = ownerReadDbContext;
    }

    #endregion

    #region Handlers



    /// <summary>
    ///
    /// </summary>
    public async Task<GetOrganizationDto> Handle(GetOrganizationByIdRequest request, CancellationToken cancellationToken)
    {
        var organization = await _ownerReadDbContext
            .Organizations.Find(e => e.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (organization == null)
            throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Organization);

        return _mapper.Map<GetOrganizationDto>(organization);
    }

    #endregion

    #region Private Methods




    #endregion
}
