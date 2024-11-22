using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTaskById;

public class GetTaskByIdGrpcEndpoint : GetTaskByIdGrpcService.GetTaskByIdGrpcServiceBase
{
    private readonly IRequestDispatcher _requestDispatcher;
    private readonly IMapper _mapper;

    public GetTaskByIdGrpcEndpoint(IRequestDispatcher requestDispatcher, IMapper mapper)
    {
        _requestDispatcher = requestDispatcher;
        _mapper = mapper;
    }

    public override async Task<GetTaskGrpcResponse> Handle(GetTaskByIdGrpcRequest request, ServerCallContext context)
    {
        var task = await _requestDispatcher.SendQuery(new GetTaskByIdRequest(request.Id));
        return _mapper.Map<GetTaskGrpcResponse>(task.Value);
    }
}
