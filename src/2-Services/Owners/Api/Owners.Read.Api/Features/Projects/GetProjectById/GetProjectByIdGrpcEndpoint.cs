using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectById;

public class GetProjectByIdGrpcEndpoint : GetProjectByIdGrpcService.GetProjectByIdGrpcServiceBase
{
    private readonly IRequestDispatcher _requestDispatcher;
    private readonly IMapper _mapper;

    public GetProjectByIdGrpcEndpoint(IRequestDispatcher requestDispatcher, IMapper mapper)
    {
        _requestDispatcher = requestDispatcher;
        _mapper = mapper;
    }

    public override async Task<GetProjectGrpcResponse> Handle(GetProjectByIdGrpcRequest request, ServerCallContext context)
    {
        var project = await _requestDispatcher.SendQuery(new GetProjectByIdRequest(request.Id));
        return _mapper.Map<GetProjectGrpcResponse>(project.Value);
    }
}
