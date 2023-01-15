using AutoMapper;
using Grpc.Core;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTaskById
{

    public class GetTaskByIdGrpcEndpoint : GetTaskByIdGrpcService.GetTaskByIdGrpcServiceBase
    {
        private readonly IInMemoryBus _inMemoryBus;
        private readonly IMapper _mapper;
        public GetTaskByIdGrpcEndpoint(IInMemoryBus inMemoryBus, IMapper mapper)
        {
            _inMemoryBus = inMemoryBus;
            _mapper = mapper;
        }

        public override async Task<GetTaskGrpcResponse> Handle(GetTaskByIdGrpcRequest request, ServerCallContext context)
        {
            var task = await _inMemoryBus.SendQuery(new GetTaskByIdRequest(request.Id));
            return _mapper.Map<GetTaskGrpcResponse>(task.Value);
        }
    }

}