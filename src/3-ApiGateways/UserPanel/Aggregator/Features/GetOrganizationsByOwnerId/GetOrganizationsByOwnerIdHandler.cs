using AutoMapper;
using Grpc.Core;
using MediatR;
using System.Threading;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetOrganizationsByOwnerIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetProjectsByOrganizationIdGrpcService;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetOrganizationsByOwnerId
{
    public class GetOrganizationsByOwnerIdHandler : BaseQueryHandler, IRequestHandler<GetOrganizationsByOwnerIdRequest, IEnumerable<OrganizationDetailsViewModel>>
    {
        #region Fields

        private readonly GetOrganizationsByOwnerIdGrpcServiceClient _getOrganizationsByOwnerIdGrpcServiceClient;
        private readonly GetProjectsByOrganizationIdGrpcServiceClient _getProjectsByOrganizationIdGrpcServiceClient;

        #endregion

        #region Ctors

        public GetOrganizationsByOwnerIdHandler(IMapper mapper, GetOrganizationsByOwnerIdGrpcServiceClient getOrganizationsByOwnerIdGrpcServiceClient, GetProjectsByOrganizationIdGrpcServiceClient getProjectsByOrganizationIdGrpcServiceClient) : base(mapper)
        {
            _getOrganizationsByOwnerIdGrpcServiceClient = getOrganizationsByOwnerIdGrpcServiceClient;
            _getProjectsByOrganizationIdGrpcServiceClient = getProjectsByOrganizationIdGrpcServiceClient;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<OrganizationDetailsViewModel>> Handle(GetOrganizationsByOwnerIdRequest request, CancellationToken cancellationToken)
        {
            var organizationsDetails = new List<OrganizationDetailsViewModel>();

            var organizationsCall = _getOrganizationsByOwnerIdGrpcServiceClient.Handle(new GetOrganizationsByOwnerIdGrpcRequest { OwnerId = request.OwnerId });

            while (await organizationsCall.ResponseStream.MoveNext(cancellationToken))
            {
                var currentOrganization = organizationsCall.ResponseStream.Current;

                var organizationDetails = await GetOrganizationDetailsAsync(currentOrganization);

                organizationsDetails.Add(organizationDetails);
            }

            return organizationsDetails.AsEnumerable();
        }



        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private async Task<OrganizationDetailsViewModel> GetOrganizationDetailsAsync(OrganizationBasicInfoGrpcResponse organizationGrpcResponse)
        {
            return new OrganizationDetailsViewModel
            {
                Organization = MapToOrganizationDto(organizationGrpcResponse),
                Projects = await GetProjectsAndMapToDto(organizationGrpcResponse.Id),

                //TODO get other details here
                //Boards = ... ,
                //Reports = ... ,
            };
        }



        /// <summary>
        /// 
        /// </summary>
        private OrganizationBasicInfoDto MapToOrganizationDto(OrganizationBasicInfoGrpcResponse organizationGrpcResponse)
        {
            return _mapper.Map<OrganizationBasicInfoDto>(organizationGrpcResponse);
        }



        /// <summary>
        /// 
        /// </summary>
        private async Task<IEnumerable<ProjectBasicInfoDto>> GetProjectsAndMapToDto(string organizationId)
        {
            var projectsDto = new List<ProjectBasicInfoDto>();

            var projectsCall = _getProjectsByOrganizationIdGrpcServiceClient.Handle(new GetProjectsByOrganizationIdGrpcRequest { OrganizationId = organizationId });

            await foreach (var response in projectsCall.ResponseStream.ReadAllAsync())
                projectsDto.Add(_mapper.Map<ProjectBasicInfoDto>(response));

            return projectsDto;
        }



        #endregion

    }
}
