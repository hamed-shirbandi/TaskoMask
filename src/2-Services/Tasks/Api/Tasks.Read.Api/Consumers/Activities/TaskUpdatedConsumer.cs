using System.Threading.Tasks;
using MassTransit;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Tasks.Read.Api.Consumers.Activities;

public class TaskUpdatedConsumer : BaseConsumer<TaskUpdated>
{
    private readonly TaskReadDbContext _taskReadDbContext;

    public TaskUpdatedConsumer(IRequestDispatcher requestDispatcher, TaskReadDbContext taskReadDbContext)
        : base(requestDispatcher)
    {
        _taskReadDbContext = taskReadDbContext;
    }

    public override async Task ConsumeMessage(ConsumeContext<TaskUpdated> context)
    {
        var activity = new Domain.Activity() { TaskId = context.Message.Id, Description = "Task Updated" };

        await _taskReadDbContext.Activities.InsertOneAsync(activity);
    }
}
