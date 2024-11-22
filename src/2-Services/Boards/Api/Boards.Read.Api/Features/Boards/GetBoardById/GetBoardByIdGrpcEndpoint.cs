using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardById;

public class GetBoardByIdGrpcEndpoint : GetBoardByIdGrpcService.GetBoardByIdGrpcServiceBase
{
    private readonly IRequestDispatcher _requestDispatcher;
    private readonly IMapper _mapper;

    public GetBoardByIdGrpcEndpoint(IRequestDispatcher requestDispatcher, IMapper mapper)
    {
        _requestDispatcher = requestDispatcher;
        _mapper = mapper;
    }

    public override async Task<GetBoardGrpcResponse> Handle(GetBoardByIdGrpcRequest request, ServerCallContext context)
    {
        var board = await _requestDispatcher.SendQuery(new GetBoardByIdRequest(request.Id));
        return _mapper.Map<GetBoardGrpcResponse>(board.Value);
    }
}
