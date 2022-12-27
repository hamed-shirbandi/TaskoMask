using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using System.Threading.Tasks;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;
using TaskoMask.Services.Boards.Read.Api.Domain;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetProjectByIdGrpcService;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using AutoMapper;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Boards
{
    public class BoardAddedConsumer : BaseConsumer<BoardAdded>
    {
        private readonly BoardReadDbContext _boardReadDbContext;
        private readonly GetProjectByIdGrpcServiceClient _getProjectByIdGrpcServiceClient;
        protected readonly IMapper _mapper;


        public BoardAddedConsumer(IInMemoryBus inMemoryBus, BoardReadDbContext boardReadDbContext, GetProjectByIdGrpcServiceClient getProjectByIdGrpcServiceClient, IMapper mapper) : base(inMemoryBus)
        {
            _boardReadDbContext = boardReadDbContext;
            _getProjectByIdGrpcServiceClient = getProjectByIdGrpcServiceClient;
            _mapper = mapper;
        }



        /// <summary>
        /// 
        /// </summary>
        public override async Task ConsumeMessage(ConsumeContext<BoardAdded> context)
        {
            var project =await GetProjectFromRpcClientAsync(context.Message.ProjectId);

            var board = new Board(context.Message.Id)
            {
                Name = context.Message.Name,
                Description = context.Message.Description,
                ProjectId = context.Message.ProjectId,
                OrganizationId= project.OrganizationId,
                OrganizationName = project.OrganizationName,
                ProjectName = project.Name,
                OwnerId = project.OwnerId,
            };

            await _boardReadDbContext.Boards.InsertOneAsync(board);
        }



        /// <summary>
        /// 
        /// </summary>
        private async Task<GetProjectDto> GetProjectFromRpcClientAsync(string projectId)
        {
            var projectGrpcResponse = await _getProjectByIdGrpcServiceClient.HandleAsync(new GetProjectByIdGrpcRequest { Id = projectId });
            
            return _mapper.Map<GetProjectDto>(projectGrpcResponse);
        }

    }
}
