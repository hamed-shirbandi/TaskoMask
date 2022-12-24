using AutoMapper;
using Grpc.Core;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationsByOwnerId
{
    public class GetOrganizationsByOwnerIdGrpcEndpoint : GetOrganizationsByOwnerIdGrpcService.GetOrganizationsByOwnerIdGrpcServiceBase
    {
        private readonly IInMemoryBus _inMemoryBus;
        private readonly IMapper _mapper;
        public GetOrganizationsByOwnerIdGrpcEndpoint(IInMemoryBus inMemoryBus, IMapper mapper)
        {
            _inMemoryBus = inMemoryBus;
            _mapper = mapper;
        }

        public override async Task Handle(GetOrganizationsByOwnerIdGrpcRequest request, IServerStreamWriter<GetOrganizationGrpcResponse> responseStream, ServerCallContext context)
        {
            var organizations = await _inMemoryBus.SendQuery(new GetOrganizationsByOwnerIdRequest(request.OwnerId));
            foreach (var organization in organizations.Value)
                await responseStream.WriteAsync(_mapper.Map<GetOrganizationGrpcResponse>(organization));
        }

    }

}