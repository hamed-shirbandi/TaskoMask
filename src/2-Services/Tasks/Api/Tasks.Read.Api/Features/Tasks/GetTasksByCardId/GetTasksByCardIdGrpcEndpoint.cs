using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTasksByCardId;

public class GetTasksByCardIdGrpcEndpoint : GetTasksByCardIdGrpcService.GetTasksByCardIdGrpcServiceBase
{
    private readonly IRequestDispatcher _requestDispatcher;
    private readonly IMapper _mapper;

    public GetTasksByCardIdGrpcEndpoint(IRequestDispatcher requestDispatcher, IMapper mapper)
    {
        _requestDispatcher = requestDispatcher;
        _mapper = mapper;
    }

    public override async Task Handle(
        GetTasksByCardIdGrpcRequest request,
        IServerStreamWriter<GetTaskGrpcResponse> responseStream,
        ServerCallContext context
    )
    {
        var tasks = await _requestDispatcher.SendQuery(new GetTasksByCardIdRequest(request.CardId));
        foreach (var task in tasks.Value)
            await responseStream.WriteAsync(_mapper.Map<GetTaskGrpcResponse>(task));
    }
}
