using AutoMapper;
using Grpc.Core;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Activities;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetActivitiesByTaskIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetCommentsByTaskIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetTaskByIdGrpcService;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetTaskById
{
    public class GetTaskByIdHandler : BaseQueryHandler, IRequestHandler<GetTaskByIdRequest, TaskDetailsViewModel>
    {
        #region Fields

        private readonly GetTaskByIdGrpcServiceClient _getTaskByIdGrpcServiceClient;
        private readonly GetCommentsByTaskIdGrpcServiceClient _getCommentsByTaskIdGrpcServiceClient;
        private readonly GetActivitiesByTaskIdGrpcServiceClient _getActivitiesByTaskIdGrpcServiceClient;

        #endregion

        #region Ctors

        public GetTaskByIdHandler(IMapper mapper, GetTaskByIdGrpcServiceClient getTaskByIdGrpcServiceClient, GetActivitiesByTaskIdGrpcServiceClient getActivitiesByTaskIdGrpcServiceClient, GetCommentsByTaskIdGrpcServiceClient getCommentsByTaskIdGrpcServiceClient) : base(mapper)
        {
            _getTaskByIdGrpcServiceClient = getTaskByIdGrpcServiceClient;
            _getActivitiesByTaskIdGrpcServiceClient = getActivitiesByTaskIdGrpcServiceClient;
            _getCommentsByTaskIdGrpcServiceClient = getCommentsByTaskIdGrpcServiceClient;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<TaskDetailsViewModel> Handle(GetTaskByIdRequest request, CancellationToken cancellationToken)
        {

            return new TaskDetailsViewModel
            {
                Task =await GetTaskAsync(request.Id, cancellationToken),
                Comments = await GetCommentsAsync(request.Id, cancellationToken),
                Activities = await GetActivitiesAsync(request.Id, cancellationToken),
            };

        }


        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private async Task<GetTaskDto> GetTaskAsync(string taskId, CancellationToken cancellationToken)
        {
            var projectGrpcResponse =await _getTaskByIdGrpcServiceClient.HandleAsync(new GetTaskByIdGrpcRequest { Id = taskId }, cancellationToken: cancellationToken);

            return _mapper.Map<GetTaskDto>(projectGrpcResponse);
        }




        /// <summary>
        /// 
        /// </summary>
        private async Task<IEnumerable<GetCommentDto>> GetCommentsAsync(string taskId, CancellationToken cancellationToken)
        {
            var comments = new List<GetCommentDto>();

            var commentsGrpcCall = _getCommentsByTaskIdGrpcServiceClient.Handle(new GetCommentsByTaskIdGrpcRequest { TaskId = taskId },cancellationToken: cancellationToken);

            await foreach (var response in commentsGrpcCall.ResponseStream.ReadAllAsync())
                comments.Add(_mapper.Map<GetCommentDto>(response));

            return comments;
        }



        /// <summary>
        /// 
        /// </summary>
        private async Task<IEnumerable<GetActivityDto>> GetActivitiesAsync(string taskId, CancellationToken cancellationToken)
        {
            var activities = new List<GetActivityDto>();

            var activitiesGrpcCall = _getActivitiesByTaskIdGrpcServiceClient.Handle(new GetActivitiesByTaskIdGrpcRequest { TaskId = taskId }, cancellationToken: cancellationToken);

            await foreach (var response in activitiesGrpcCall.ResponseStream.ReadAllAsync())
                activities.Add(_mapper.Map<GetActivityDto>(response));

            return activities;
        }





        #endregion

    }
}
