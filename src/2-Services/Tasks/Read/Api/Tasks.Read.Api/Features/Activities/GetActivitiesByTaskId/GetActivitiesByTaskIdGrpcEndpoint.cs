using AutoMapper;
using Grpc.Core;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Activities.GetActivitiesByTaskId
{

    public class GetActivitiesByTaskIdGrpcEndpoint : GetActivitiesByTaskIdGrpcService.GetActivitiesByTaskIdGrpcServiceBase
    {
        private readonly IInMemoryBus _inMemoryBus;
        private readonly IMapper _mapper;
        public GetActivitiesByTaskIdGrpcEndpoint(IInMemoryBus inMemoryBus, IMapper mapper)
        {
            _inMemoryBus = inMemoryBus;
            _mapper = mapper;
        }

        public override async Task Handle(GetActivitiesByTaskIdGrpcRequest request, IServerStreamWriter<GetActivityGrpcResponse> responseStream, ServerCallContext context)
        {
            var comments = await _inMemoryBus.SendQuery(new GetActivitiesByTaskIdRequest(request.TaskId));
            foreach (var comment in comments.Value)
                await responseStream.WriteAsync(_mapper.Map<GetActivityGrpcResponse>(comment));
        }
    }

}