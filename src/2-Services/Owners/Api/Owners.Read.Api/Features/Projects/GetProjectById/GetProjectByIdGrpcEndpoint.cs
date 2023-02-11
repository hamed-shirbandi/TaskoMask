using AutoMapper;
using Grpc.Core;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectById
{

    public class GetProjectByIdGrpcEndpoint : GetProjectByIdGrpcService.GetProjectByIdGrpcServiceBase
    {
        private readonly IInMemoryBus _inMemoryBus;
        private readonly IMapper _mapper;
        public GetProjectByIdGrpcEndpoint(IInMemoryBus inMemoryBus, IMapper mapper)
        {
            _inMemoryBus = inMemoryBus;
            _mapper = mapper;
        }

        public override async Task<GetProjectGrpcResponse> Handle(GetProjectByIdGrpcRequest request, ServerCallContext context)
        {
            var project = await _inMemoryBus.SendQuery(new GetProjectByIdRequest(request.Id));
            return _mapper.Map<GetProjectGrpcResponse>(project.Value);
        }
    }

}