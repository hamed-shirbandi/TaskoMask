using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardById;

public class GetCardByIdGrpcEndpoint : GetCardByIdGrpcService.GetCardByIdGrpcServiceBase
{
    private readonly IRequestDispatcher _requestDispatcher;
    private readonly IMapper _mapper;

    public GetCardByIdGrpcEndpoint(IRequestDispatcher requestDispatcher, IMapper mapper)
    {
        _requestDispatcher = requestDispatcher;
        _mapper = mapper;
    }

    public override async Task<GetCardGrpcResponse> Handle(GetCardByIdGrpcRequest request, ServerCallContext context)
    {
        var board = await _requestDispatcher.SendQuery(new GetCardByIdRequest(request.Id));
        return _mapper.Map<GetCardGrpcResponse>(board.Value);
    }
}
