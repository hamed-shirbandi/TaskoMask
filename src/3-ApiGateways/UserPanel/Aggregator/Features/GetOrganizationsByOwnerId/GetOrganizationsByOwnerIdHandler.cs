using AutoMapper;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetOrganizationsByOwnerIdGrpcService;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetOrganizationsByOwnerId
{
    public class GetOrganizationsByOwnerIdHandler : BaseQueryHandler, IRequestHandler<GetOrganizationsByOwnerIdRequest, IEnumerable<OrganizationDetailsViewModel>>
    {
        #region Fields

        private readonly GetOrganizationsByOwnerIdGrpcServiceClient _getOrganizationsByOwnerIdGrpcServiceClient;

        #endregion

        #region Ctors

        public GetOrganizationsByOwnerIdHandler(IMapper mapper, GetOrganizationsByOwnerIdGrpcServiceClient getOrganizationsByOwnerIdGrpcServiceClient) : base(mapper)
        {
            _getOrganizationsByOwnerIdGrpcServiceClient = getOrganizationsByOwnerIdGrpcServiceClient;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<OrganizationDetailsViewModel>> Handle(GetOrganizationsByOwnerIdRequest request, CancellationToken cancellationToken)
        {
            var organizationsDetail = new List<OrganizationDetailsViewModel>();

            var organizationsCall = _getOrganizationsByOwnerIdGrpcServiceClient.Handle(new GetOrganizationsByOwnerIdGrpcRequest { OwnerId = request.OwnerId });

            while (await organizationsCall.ResponseStream.MoveNext(cancellationToken))
            {
                //TODO get details here
            }

            return organizationsDetail;
        }



        #endregion

        #region Private Methods




        #endregion
    }
}
