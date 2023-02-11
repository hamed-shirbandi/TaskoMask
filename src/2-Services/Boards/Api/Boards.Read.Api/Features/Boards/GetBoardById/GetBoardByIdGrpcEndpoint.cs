using AutoMapper;
using Grpc.Core;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardById
{

    public class GetBoardByIdGrpcEndpoint : GetBoardByIdGrpcService.GetBoardByIdGrpcServiceBase
    {
        private readonly IInMemoryBus _inMemoryBus;
        private readonly IMapper _mapper;
        public GetBoardByIdGrpcEndpoint(IInMemoryBus inMemoryBus, IMapper mapper)
        {
            _inMemoryBus = inMemoryBus;
            _mapper = mapper;
        }

        public override async Task<GetBoardGrpcResponse> Handle(GetBoardByIdGrpcRequest request, ServerCallContext context)
        {
            var board = await _inMemoryBus.SendQuery(new GetBoardByIdRequest(request.Id));
            return _mapper.Map<GetBoardGrpcResponse>(board.Value);
        }
    }

}