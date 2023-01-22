using AutoMapper;
using Grpc.Core;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetBoardsByOrganizationIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetOrganizationsByOwnerIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetProjectsByOrganizationIdGrpcService;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetOrganizationsByOwnerId
{
    public class GetOrganizationsByOwnerIdHandler : BaseQueryHandler, IRequestHandler<GetOrganizationsByOwnerIdRequest, IEnumerable<OrganizationDetailsViewModel>>
    {
        #region Fields

        private readonly GetOrganizationsByOwnerIdGrpcServiceClient _getOrganizationsByOwnerIdGrpcServiceClient;
        private readonly GetProjectsByOrganizationIdGrpcServiceClient _getProjectsByOrganizationIdGrpcServiceClient;
        private readonly GetBoardsByOrganizationIdGrpcServiceClient _getBoardsByOrganizationIdGrpcServiceClient;

        #endregion

        #region Ctors

        public GetOrganizationsByOwnerIdHandler(IMapper mapper, GetOrganizationsByOwnerIdGrpcServiceClient getOrganizationsByOwnerIdGrpcServiceClient, GetProjectsByOrganizationIdGrpcServiceClient getProjectsByOrganizationIdGrpcServiceClient, GetBoardsByOrganizationIdGrpcServiceClient getBoardsByOrganizationIdGrpcServiceClient) : base(mapper)
        {
            _getOrganizationsByOwnerIdGrpcServiceClient = getOrganizationsByOwnerIdGrpcServiceClient;
            _getProjectsByOrganizationIdGrpcServiceClient = getProjectsByOrganizationIdGrpcServiceClient;
            _getBoardsByOrganizationIdGrpcServiceClient = getBoardsByOrganizationIdGrpcServiceClient;
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
                    Boards = await GetBoardsAsync(currentOrganizationGrpcResponse.Id),
                    //Will be done by issue #143
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
        private GetOrganizationDto MapToOrganization(GetOrganizationGrpcResponse organizationGrpcResponse)
        {
            return _mapper.Map<GetOrganizationDto>(organizationGrpcResponse);
        }



        /// <summary>
        /// 
        /// </summary>
        private async Task<IEnumerable<GetProjectDto>> GetProjectsAsync(string organizationId)
        {
            var projects = new List<GetProjectDto>();

            var projectsGrpcCall = _getProjectsByOrganizationIdGrpcServiceClient.Handle(new GetProjectsByOrganizationIdGrpcRequest { OrganizationId = organizationId });

            await foreach (var response in projectsGrpcCall.ResponseStream.ReadAllAsync())
                projects.Add(_mapper.Map<GetProjectDto>(response));

            return projects;
        }



        /// <summary>
        /// 
        /// </summary>
        private async Task<IEnumerable<GetBoardDto>> GetBoardsAsync(string organizationId)
        {
            var boards = new List<GetBoardDto>();
            var boardsGrpcCall = _getBoardsByOrganizationIdGrpcServiceClient.Handle(new GetBoardsByOrganizationIdGrpcRequest { OrganizationId = organizationId });

            await foreach (var response in boardsGrpcCall.ResponseStream.ReadAllAsync())
                boards.Add(_mapper.Map<GetBoardDto>(response));

            return boards;
        }



        #endregion

    }
}
