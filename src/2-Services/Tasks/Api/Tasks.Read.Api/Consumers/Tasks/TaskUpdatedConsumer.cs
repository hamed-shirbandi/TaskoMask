using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TaskoMask.Services.Tasks.Read.Api.Consumers.Tasks
{
    public class TaskUpdatedConsumer : BaseConsumer<TaskUpdated>
    {
        private readonly TaskReadDbContext _taskReadDbContext;


        public TaskUpdatedConsumer(IInMemoryBus inMemoryBus, TaskReadDbContext taskReadDbContext) : base(inMemoryBus)
        {
            _taskReadDbContext = taskReadDbContext;
        }


        public override async Task ConsumeMessage(ConsumeContext<TaskUpdated> context)
        {
            var task = await _taskReadDbContext.Tasks.Find(e => e.Id == context.Message.Id).FirstOrDefaultAsync();

            task.Title = context.Message.Title;
            task.Description = context.Message.Description;
            task.SetAsUpdated();

            await _taskReadDbContext.Tasks.ReplaceOneAsync(p => p.Id == task.Id, task, new ReplaceOptions() { IsUpsert = false });
        }
    }
}
