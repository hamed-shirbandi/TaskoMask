using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Comments.GetCommentsByTaskId;

public class GetCommentsByTaskIdGrpcEndpoint : GetCommentsByTaskIdGrpcService.GetCommentsByTaskIdGrpcServiceBase
{
    private readonly IRequestDispatcher _requestDispatcher;
    private readonly IMapper _mapper;

    public GetCommentsByTaskIdGrpcEndpoint(IRequestDispatcher requestDispatcher, IMapper mapper)
    {
        _requestDispatcher = requestDispatcher;
        _mapper = mapper;
    }

    public override async Task Handle(
        GetCommentsByTaskIdGrpcRequest request,
        IServerStreamWriter<GetCommentGrpcResponse> responseStream,
        ServerCallContext context
    )
    {
        var comments = await _requestDispatcher.SendQuery(new GetCommentsByTaskIdRequest(request.TaskId));
        foreach (var comment in comments.Value)
            await responseStream.WriteAsync(_mapper.Map<GetCommentGrpcResponse>(comment));
    }
}
