using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardsByProjectId;

public class GetBoardsByProjectIdGrpcEndpoint : GetBoardsByProjectIdGrpcService.GetBoardsByProjectIdGrpcServiceBase
{
    private readonly IRequestDispatcher _requestDispatcher;
    private readonly IMapper _mapper;

    public GetBoardsByProjectIdGrpcEndpoint(IRequestDispatcher requestDispatcher, IMapper mapper)
    {
        _requestDispatcher = requestDispatcher;
        _mapper = mapper;
    }

    public override async Task Handle(
        GetBoardsByProjectIdGrpcRequest request,
        IServerStreamWriter<GetBoardGrpcResponse> responseStream,
        ServerCallContext context
    )
    {
        var boards = await _requestDispatcher.SendQuery(new GetBoardsByProjectIdRequest(request.ProjectId));
        foreach (var board in boards.Value)
            await responseStream.WriteAsync(_mapper.Map<GetBoardGrpcResponse>(board));
    }
}
