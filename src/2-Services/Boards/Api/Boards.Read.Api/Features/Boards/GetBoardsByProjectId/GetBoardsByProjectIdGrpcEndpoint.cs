using AutoMapper;
using Grpc.Core;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Boards.Read.Api.Features.Boards.GetBoardsByProjectId
{

    public class GetBoardsByProjectIdGrpcEndpoint : GetBoardsByProjectIdGrpcService.GetBoardsByProjectIdGrpcServiceBase
    {
        private readonly IInMemoryBus _inMemoryBus;
        private readonly IMapper _mapper;
        public GetBoardsByProjectIdGrpcEndpoint(IInMemoryBus inMemoryBus, IMapper mapper)
        {
            _inMemoryBus = inMemoryBus;
            _mapper = mapper;
        }

        public override async Task Handle(GetBoardsByProjectIdGrpcRequest request, IServerStreamWriter<GetBoardGrpcResponse> responseStream, ServerCallContext context)
        {
            var boards = await _inMemoryBus.SendQuery(new GetBoardsByProjectIdRequest(request.ProjectId));
            foreach (var board in boards.Value)
                await responseStream.WriteAsync(_mapper.Map<GetBoardGrpcResponse>(board));
        }
    }

}