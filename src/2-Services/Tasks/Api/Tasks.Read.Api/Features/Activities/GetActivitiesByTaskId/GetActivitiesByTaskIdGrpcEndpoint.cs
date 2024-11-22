using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Activities.GetActivitiesByTaskId;

public class GetActivitiesByTaskIdGrpcEndpoint : GetActivitiesByTaskIdGrpcService.GetActivitiesByTaskIdGrpcServiceBase
{
    private readonly IRequestDispatcher _requestDispatcher;
    private readonly IMapper _mapper;

    public GetActivitiesByTaskIdGrpcEndpoint(IRequestDispatcher requestDispatcher, IMapper mapper)
    {
        _requestDispatcher = requestDispatcher;
        _mapper = mapper;
    }

    public override async Task Handle(
        GetActivitiesByTaskIdGrpcRequest request,
        IServerStreamWriter<GetActivityGrpcResponse> responseStream,
        ServerCallContext context
    )
    {
        var comments = await _requestDispatcher.SendQuery(new GetActivitiesByTaskIdRequest(request.TaskId));
        foreach (var comment in comments.Value)
            await responseStream.WriteAsync(_mapper.Map<GetActivityGrpcResponse>(comment));
    }
}
