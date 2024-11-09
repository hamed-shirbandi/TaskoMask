using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectsByOrganizationId;

public class GetProjectsByOrganizationIdHandler : BaseQueryHandler, IRequestHandler<GetProjectsByOrganizationIdRequest, IEnumerable<GetProjectDto>>
{
    #region Fields

    private readonly OwnerReadDbContext _ownerReadDbContext;

    #endregion

    #region Ctors

    public GetProjectsByOrganizationIdHandler(OwnerReadDbContext ownerReadDbContext, IMapper mapper)
        : base(mapper)
    {
        _ownerReadDbContext = ownerReadDbContext;
    }

    #endregion

    #region Handlers



    /// <summary>
    ///
    /// </summary>
    public async Task<IEnumerable<GetProjectDto>> Handle(GetProjectsByOrganizationIdRequest request, CancellationToken cancellationToken)
    {
        var projects = await _ownerReadDbContext.Projects.AsQueryable().Where(o => o.OrganizationId == request.OrganizationId).ToListAsync();

        return _mapper.Map<IEnumerable<GetProjectDto>>(projects);
    }

    #endregion

    #region Private Methods




    #endregion
}
