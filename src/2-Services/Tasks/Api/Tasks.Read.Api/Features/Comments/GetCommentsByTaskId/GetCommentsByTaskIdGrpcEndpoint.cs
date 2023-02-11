using AutoMapper;
using Grpc.Core;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Comments.GetCommentsByTaskId
{

    public class GetCommentsByTaskIdGrpcEndpoint : GetCommentsByTaskIdGrpcService.GetCommentsByTaskIdGrpcServiceBase
    {
        private readonly IInMemoryBus _inMemoryBus;
        private readonly IMapper _mapper;
        public GetCommentsByTaskIdGrpcEndpoint(IInMemoryBus inMemoryBus, IMapper mapper)
        {
            _inMemoryBus = inMemoryBus;
            _mapper = mapper;
        }

        public override async Task Handle(GetCommentsByTaskIdGrpcRequest request, IServerStreamWriter<GetCommentGrpcResponse> responseStream, ServerCallContext context)
        {
            var comments = await _inMemoryBus.SendQuery(new GetCommentsByTaskIdRequest(request.TaskId));
            foreach (var comment in comments.Value)
                await responseStream.WriteAsync(_mapper.Map<GetCommentGrpcResponse>(comment));
        }
    }

}