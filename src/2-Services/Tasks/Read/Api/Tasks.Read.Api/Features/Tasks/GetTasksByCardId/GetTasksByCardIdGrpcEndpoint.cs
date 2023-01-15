using AutoMapper;
using Grpc.Core;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTasksByCardId
{

    public class GetTasksByCardIdGrpcEndpoint : GetTasksByCardIdGrpcService.GetTasksByCardIdGrpcServiceBase
    {
        private readonly IInMemoryBus _inMemoryBus;
        private readonly IMapper _mapper;
        public GetTasksByCardIdGrpcEndpoint(IInMemoryBus inMemoryBus, IMapper mapper)
        {
            _inMemoryBus = inMemoryBus;
            _mapper = mapper;
        }

        public override async Task Handle(GetTasksByCardIdGrpcRequest request, IServerStreamWriter<GetTaskGrpcResponse> responseStream, ServerCallContext context)
        {
            var tasks = await _inMemoryBus.SendQuery(new GetTasksByCardIdRequest(request.CardId));
            foreach (var task in tasks.Value)
                await responseStream.WriteAsync(_mapper.Map<GetTaskGrpcResponse>(task));
        }
    }

}