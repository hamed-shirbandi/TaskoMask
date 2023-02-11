using AutoMapper;
using Grpc.Core;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardsByBoardId
{

    public class GetCardsByBoardIdGrpcEndpoint : GetCardsByBoardIdGrpcService.GetCardsByBoardIdGrpcServiceBase
    {
        private readonly IInMemoryBus _inMemoryBus;
        private readonly IMapper _mapper;
        public GetCardsByBoardIdGrpcEndpoint(IInMemoryBus inMemoryBus, IMapper mapper)
        {
            _inMemoryBus = inMemoryBus;
            _mapper = mapper;
        }

        public override async Task Handle(GetCardsByBoardIdGrpcRequest request, IServerStreamWriter<GetCardGrpcResponse> responseStream, ServerCallContext context)
        {
            var cards = await _inMemoryBus.SendQuery(new GetCardsByBoardIdRequest(request.BoardId));
            foreach (var card in cards.Value)
                await responseStream.WriteAsync(_mapper.Map<GetCardGrpcResponse>(card));
        }
    }

}