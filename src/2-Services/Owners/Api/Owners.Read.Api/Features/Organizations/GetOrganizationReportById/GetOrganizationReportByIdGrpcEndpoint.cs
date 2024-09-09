using AutoMapper;
using Grpc.Core;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationReportById;


public class GetOrganizationReportByIdGrpcEndpoint : GetOrganizationReportIdGrpcService.GetOrganizationReportIdGrpcServiceBase
{
    private readonly IInMemoryBus _inMemoryBus;
    private readonly IMapper _mapper;

    public GetOrganizationReportByIdGrpcEndpoint(IInMemoryBus inMemoryBus, IMapper mapper)
    {
        _inMemoryBus = inMemoryBus;
        _mapper = mapper;
    }

    public override async Task<GetOrganizationReportGrpcResponse> Handle(GetOrganizationReportIdGrpcRequest request, ServerCallContext context)
    {
        var report = await _inMemoryBus.SendQuery(new GetOrganizationReportByIdRequest(request.OrganizationId));
        return _mapper.Map<GetOrganizationReportGrpcResponse>(report.Value);
    }
}
