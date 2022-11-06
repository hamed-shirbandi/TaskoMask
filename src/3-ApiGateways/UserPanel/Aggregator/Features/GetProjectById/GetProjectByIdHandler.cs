using AutoMapper;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetProjectByIdGrpcService;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetProjectById
{
    public class GetProjectByIdHandler : BaseQueryHandler, IRequestHandler<GetProjectByIdRequest, ProjectDetailsViewModel>
    {
        #region Fields

        private readonly GetProjectByIdGrpcServiceClient _getProjectByIdGrpcServiceClient;

        #endregion

        #region Ctors

        public GetProjectByIdHandler(IMapper mapper, GetProjectByIdGrpcServiceClient getProjectByIdGrpcServiceClient) : base(mapper)
        {
            _getProjectByIdGrpcServiceClient = getProjectByIdGrpcServiceClient;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdRequest request, CancellationToken cancellationToken)
        {
            var projectGrpcResponse = _getProjectByIdGrpcServiceClient.Handle(new GetProjectByIdGrpcRequest { Id = request.Id });

            return new ProjectDetailsViewModel
            {
                Project = MapToProjectDto(projectGrpcResponse),
                //TODO get other details here
                //Boards = ... ,
            };

        }


        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private ProjectOutputDto MapToProjectDto(ProjectBasicInfoGrpcResponse projectGrpcResponse)
        {
            return _mapper.Map<ProjectOutputDto>(projectGrpcResponse);
        }




        #endregion

    }
}
