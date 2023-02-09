using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TaskoMask.Services.Tasks.Read.Api.Consumers.Tasks
{
    public class CardUpdatedConsumer : BaseConsumer<CardUpdated>
    {
        private readonly TaskReadDbContext _taskReadDbContext;


        public CardUpdatedConsumer(IInMemoryBus inMemoryBus, TaskReadDbContext taskReadDbContext) : base(inMemoryBus)
        {
            _taskReadDbContext = taskReadDbContext;
        }


        public override async Task ConsumeMessage(ConsumeContext<CardUpdated> context)
        {
            var tasks = await _taskReadDbContext.Tasks.Find(e => e.CardId == context.Message.Id).ToListAsync();

            foreach (var task in tasks)
            {
                task.CardName = context.Message.Name;
                task.CardType = context.Message.Type;
                task.SetAsUpdated();
                await _taskReadDbContext.Tasks.ReplaceOneAsync(p => p.Id == task.Id, task, new ReplaceOptions() { IsUpsert = false });
            }
        }
    }
}
