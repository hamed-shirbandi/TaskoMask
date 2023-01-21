using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TaskoMask.Services.Tasks.Read.Api.Consumers.Activities
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
            var activity = new Domain.Activity()
            {
                TaskId = context.Message.Id,
                Description = "Task Updated",
            };

            await _taskReadDbContext.Activities.InsertOneAsync(activity);
        }
    }
}
