using AutoMapper;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
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

            return new ProjectDetailsViewModel
            {
                Project = GetProjectAndMapToDto(request.Id),
                Boards = await GetBoardsAndMapToDto(request.Id),
            };

        }


        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private ProjectBasicInfoDto GetProjectAndMapToDto(string projectId)
        {
            var projectGrpcResponse = _getProjectByIdGrpcServiceClient.Handle(new GetProjectByIdGrpcRequest { Id = projectId });

            return _mapper.Map<ProjectBasicInfoDto>(projectGrpcResponse);
        }




        /// <summary>
        /// 
        /// </summary>
        private async Task<IEnumerable<GetBoardDto>> GetBoardsAndMapToDto(string projectId)
        {
            return new List<GetBoardDto>();

            //TODO implement GetBoardsByProjectIdGrpc service and then uncomment the bellow codes

            //var boardsDto = new List<BoardBasicInfoDto>();

            //var boardsCall = _getBoardsByProjectIdGrpcServiceClient.Handle(new GetBoardsByProjectIdGrpcRequest { ProjectId = projectId });

            //await foreach (var response in boardsCall.ResponseStream.ReadAllAsync())
            //    boardsDto.Add(_mapper.Map<BoardBasicInfoDto>(response));

            //return boardsDto;
        }




        #endregion

    }
}
