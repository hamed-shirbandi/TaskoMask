using AutoMapper;
using Grpc.Core;
using MassTransit;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
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
            var organizations = new List<OrganizationDetailsViewModel>();

            var organizationsGrpcCall = _getOrganizationsByOwnerIdGrpcServiceClient.Handle(new GetOrganizationsByOwnerIdGrpcRequest { OwnerId = request.OwnerId });

            while (await organizationsGrpcCall.ResponseStream.MoveNext(cancellationToken))
            {
                var currentOrganizationGrpcResponse = organizationsGrpcCall.ResponseStream.Current;

                organizations.Add(new OrganizationDetailsViewModel
                {
                    Organization = MapToOrganization(currentOrganizationGrpcResponse),
                    Projects = await GetProjectsAsync(currentOrganizationGrpcResponse.Id),
                    Boards = await GetBoardssAsync(currentOrganizationGrpcResponse.Id),
                    //TODO get other details here
                    //Reports = ... ,
                    Reports = new OrganizationReportDto(),
                });
            }

            return organizations.AsEnumerable();
        }




        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private OrganizationBasicInfoDto MapToOrganization(OrganizationBasicInfoGrpcResponse organizationGrpcResponse)
        {
            return _mapper.Map<OrganizationBasicInfoDto>(organizationGrpcResponse);
        }



        /// <summary>
        /// 
        /// </summary>
        private async Task<IEnumerable<ProjectBasicInfoDto>> GetProjectsAsync(string organizationId)
        {
            var projects = new List<ProjectBasicInfoDto>();

            var projectsGrpcCall = _getProjectsByOrganizationIdGrpcServiceClient.Handle(new GetProjectsByOrganizationIdGrpcRequest { OrganizationId = organizationId });

            await foreach (var response in projectsGrpcCall.ResponseStream.ReadAllAsync())
                projects.Add(_mapper.Map<ProjectBasicInfoDto>(response));

            return projects;
        }



        /// <summary>
        /// 
        /// </summary>
        private async Task<IEnumerable<GetBoardDto>> GetBoardssAsync(string id)
        {
            throw new NotImplementedException();
        }



        #endregion

    }
}
