using AutoMapper;
using Grpc.Core;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectsByOrganizationId
{

    public class GetProjectsByOrganizationIdGrpcEndpoint : GetProjectsByOrganizationIdGrpcService.GetProjectsByOrganizationIdGrpcServiceBase
    {
        private readonly IInMemoryBus _inMemoryBus;
        private readonly IMapper _mapper;
        public GetProjectsByOrganizationIdGrpcEndpoint(IInMemoryBus inMemoryBus, IMapper mapper)
        {
            _inMemoryBus = inMemoryBus;
            _mapper = mapper;
        }

        public override async Task Handle(GetProjectsByOrganizationIdGrpcRequest request, IServerStreamWriter<GetProjectGrpcResponse> responseStream, ServerCallContext context)
        {
            var projects = await _inMemoryBus.SendQuery(new GetProjectsByOrganizationIdRequest(request.OrganizationId));
            foreach (var project in projects.Value)
                await responseStream.WriteAsync(_mapper.Map<GetProjectGrpcResponse>(project));
        }

    }

}