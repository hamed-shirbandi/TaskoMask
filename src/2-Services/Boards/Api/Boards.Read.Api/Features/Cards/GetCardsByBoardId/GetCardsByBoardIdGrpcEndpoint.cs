using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardsByBoardId;

public class GetCardsByBoardIdGrpcEndpoint : GetCardsByBoardIdGrpcService.GetCardsByBoardIdGrpcServiceBase
{
    private readonly IRequestDispatcher _requestDispatcher;
    private readonly IMapper _mapper;

    public GetCardsByBoardIdGrpcEndpoint(IRequestDispatcher requestDispatcher, IMapper mapper)
    {
        _requestDispatcher = requestDispatcher;
        _mapper = mapper;
    }

    public override async Task Handle(
        GetCardsByBoardIdGrpcRequest request,
        IServerStreamWriter<GetCardGrpcResponse> responseStream,
        ServerCallContext context
    )
    {
        var cards = await _requestDispatcher.SendQuery(new GetCardsByBoardIdRequest(request.BoardId));
        foreach (var card in cards.Value)
            await responseStream.WriteAsync(_mapper.Map<GetCardGrpcResponse>(card));
    }
}
