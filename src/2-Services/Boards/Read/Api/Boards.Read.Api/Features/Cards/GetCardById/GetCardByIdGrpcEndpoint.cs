using AutoMapper;
using Grpc.Core;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardById;

namespace TaskoMask.Services.Cards.Read.Api.Features.Cards.GetCardById
{

    public class GetCardByIdGrpcEndpoint : GetCardByIdGrpcService.GetCardByIdGrpcServiceBase
    {
        private readonly IInMemoryBus _inMemoryBus;
        private readonly IMapper _mapper;
        public GetCardByIdGrpcEndpoint(IInMemoryBus inMemoryBus, IMapper mapper)
        {
            _inMemoryBus = inMemoryBus;
            _mapper = mapper;
        }

        public override async Task<GetCardGrpcResponse> Handle(GetCardByIdGrpcRequest request, ServerCallContext context)
        {
            var board = await _inMemoryBus.SendQuery(new GetCardByIdRequest(request.Id));
            return _mapper.Map<GetCardGrpcResponse>(board.Value);
        }
    }

}