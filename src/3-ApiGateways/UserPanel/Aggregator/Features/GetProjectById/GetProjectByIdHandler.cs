using AutoMapper;
using Grpc.Core;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetBoardsByProjectIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetProjectByIdGrpcService;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetProjectById
{
    public class GetProjectByIdHandler : BaseQueryHandler, IRequestHandler<GetProjectByIdRequest, ProjectDetailsViewModel>
    {
        #region Fields

        private readonly GetProjectByIdGrpcServiceClient _getProjectByIdGrpcServiceClient;
        private readonly GetBoardsByProjectIdGrpcServiceClient _getBoardsByProjectIdGrpcServiceClient;

        #endregion

        #region Ctors

        public GetProjectByIdHandler(IMapper mapper, GetProjectByIdGrpcServiceClient getProjectByIdGrpcServiceClient, GetBoardsByProjectIdGrpcServiceClient getBoardsByProjectIdGrpcServiceClient) : base(mapper)
        {
            _getProjectByIdGrpcServiceClient = getProjectByIdGrpcServiceClient;
            _getBoardsByProjectIdGrpcServiceClient = getBoardsByProjectIdGrpcServiceClient;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdRequest request, CancellationToken cancellationToken)
        {

            return new ProjectDetailsViewModel
            {
                Project =await GetProjectAsync(request.Id, cancellationToken),
                Boards = await GetBoardsAsync(request.Id, cancellationToken),
            };

        }


        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private async Task<ProjectBasicInfoDto> GetProjectAsync(string projectId, CancellationToken cancellationToken)
        {
            var projectGrpcResponse =await _getProjectByIdGrpcServiceClient.HandleAsync(new GetProjectByIdGrpcRequest { Id = projectId }, cancellationToken: cancellationToken);

            return _mapper.Map<ProjectBasicInfoDto>(projectGrpcResponse);
        }




        /// <summary>
        /// 
        /// </summary>
        private async Task<IEnumerable<GetBoardDto>> GetBoardsAsync(string projectId, CancellationToken cancellationToken)
        {
            var boardsDto = new List<GetBoardDto>();

            var boardsCall = _getBoardsByProjectIdGrpcServiceClient.Handle(new GetBoardsByProjectIdGrpcRequest { ProjectId = projectId },cancellationToken: cancellationToken);

            await foreach (var response in boardsCall.ResponseStream.ReadAllAsync())
                boardsDto.Add(_mapper.Map<GetBoardDto>(response));

            return boardsDto;
        }




        #endregion

    }
}
