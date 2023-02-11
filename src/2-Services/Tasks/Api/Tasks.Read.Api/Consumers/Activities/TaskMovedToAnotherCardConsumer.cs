using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;
using System.Threading.Tasks;
using AutoMapper;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetCardByIdGrpcService;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Protos;

namespace TaskoMask.Services.Tasks.Read.Api.Consumers.Activities
{
    public class TaskMovedToAnotherCardConsumer : BaseConsumer<TaskMovedToAnotherCard>
    {
        private readonly GetCardByIdGrpcServiceClient _getCardByIdGrpcServiceClient;
        private readonly TaskReadDbContext _taskReadDbContext;
        protected readonly IMapper _mapper;


        public TaskMovedToAnotherCardConsumer(IInMemoryBus inMemoryBus, TaskReadDbContext taskReadDbContext, IMapper mapper, GetCardByIdGrpcServiceClient getCardByIdGrpcServiceClient) : base(inMemoryBus)
        {
            _taskReadDbContext = taskReadDbContext;
            _mapper = mapper;
            _getCardByIdGrpcServiceClient = getCardByIdGrpcServiceClient;
        }



        /// <summary>
        /// 
        /// </summary>
        public override async Task ConsumeMessage(ConsumeContext<TaskMovedToAnotherCard> context)
        {
            var card = await GetCardFromRpcClientAsync(context.Message.CardId);

            var activity = new Domain.Activity()
            {
                TaskId = context.Message.TaskId,
                Description = $"Moved to {card.Name}",
            };

            await _taskReadDbContext.Activities.InsertOneAsync(activity);
        }



        /// <summary>
        /// 
        /// </summary>
        private async Task<GetCardDto> GetCardFromRpcClientAsync(string cardId)
        {
            var cardGrpcResponse = await _getCardByIdGrpcServiceClient.HandleAsync(new GetCardByIdGrpcRequest { Id = cardId });

            return _mapper.Map<GetCardDto>(cardGrpcResponse);
        }
    }
}
