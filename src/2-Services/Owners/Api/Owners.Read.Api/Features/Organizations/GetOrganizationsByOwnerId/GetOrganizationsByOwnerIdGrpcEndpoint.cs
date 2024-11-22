using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationsByOwnerId;

public class GetOrganizationsByOwnerIdGrpcEndpoint : GetOrganizationsByOwnerIdGrpcService.GetOrganizationsByOwnerIdGrpcServiceBase
{
    private readonly IRequestDispatcher _requestDispatcher;
    private readonly IMapper _mapper;

    public GetOrganizationsByOwnerIdGrpcEndpoint(IRequestDispatcher requestDispatcher, IMapper mapper)
    {
        _requestDispatcher = requestDispatcher;
        _mapper = mapper;
    }

    public override async Task Handle(
        GetOrganizationsByOwnerIdGrpcRequest request,
        IServerStreamWriter<GetOrganizationGrpcResponse> responseStream,
        ServerCallContext context
    )
    {
        var organizations = await _requestDispatcher.SendQuery(new GetOrganizationsByOwnerIdRequest(request.OwnerId));
        foreach (var organization in organizations.Value)
            await responseStream.WriteAsync(_mapper.Map<GetOrganizationGrpcResponse>(organization));
    }
}
