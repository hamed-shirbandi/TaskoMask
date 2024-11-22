using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectsByOrganizationId;

public class GetProjectsByOrganizationIdGrpcEndpoint : GetProjectsByOrganizationIdGrpcService.GetProjectsByOrganizationIdGrpcServiceBase
{
    private readonly IRequestDispatcher _requestDispatcher;
    private readonly IMapper _mapper;

    public GetProjectsByOrganizationIdGrpcEndpoint(IRequestDispatcher requestDispatcher, IMapper mapper)
    {
        _requestDispatcher = requestDispatcher;
        _mapper = mapper;
    }

    public override async Task Handle(
        GetProjectsByOrganizationIdGrpcRequest request,
        IServerStreamWriter<GetProjectGrpcResponse> responseStream,
        ServerCallContext context
    )
    {
        var projects = await _requestDispatcher.SendQuery(new GetProjectsByOrganizationIdRequest(request.OrganizationId));
        foreach (var project in projects.Value)
            await responseStream.WriteAsync(_mapper.Map<GetProjectGrpcResponse>(project));
    }
}
