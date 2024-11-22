using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetCardByIdGrpcService;

namespace TaskoMask.Services.Tasks.Read.Api.Consumers.Tasks;

public class TaskMovedToAnotherCardConsumer : BaseConsumer<TaskMovedToAnotherCard>
{
    private readonly GetCardByIdGrpcServiceClient _getCardByIdGrpcServiceClient;
    private readonly TaskReadDbContext _taskReadDbContext;
    protected readonly IMapper _mapper;

    public TaskMovedToAnotherCardConsumer(
        IRequestDispatcher requestDispatcher,
        TaskReadDbContext taskReadDbContext,
        IMapper mapper,
        GetCardByIdGrpcServiceClient getCardByIdGrpcServiceClient
    )
        : base(requestDispatcher)
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

        var task = await _taskReadDbContext.Tasks.Find(e => e.Id == context.Message.TaskId).FirstOrDefaultAsync();

        task.CardId = context.Message.CardId;
        task.CardName = task.CardName;
        task.CardType = task.CardType;

        task.SetAsUpdated();

        await _taskReadDbContext.Tasks.ReplaceOneAsync(p => p.Id == task.Id, task, new ReplaceOptions() { IsUpsert = false });
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
