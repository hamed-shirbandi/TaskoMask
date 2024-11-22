using System.Threading.Tasks;
using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Tasks.Read.Api.Consumers.Tasks;

public class TaskDeletedConsumer : BaseConsumer<TaskDeleted>
{
    private readonly TaskReadDbContext _taskReadDbContext;

    public TaskDeletedConsumer(IRequestDispatcher requestDispatcher, TaskReadDbContext taskReadDbContext)
        : base(requestDispatcher)
    {
        _taskReadDbContext = taskReadDbContext;
    }

    public override async Task ConsumeMessage(ConsumeContext<TaskDeleted> context)
    {
        await _taskReadDbContext.Tasks.DeleteOneAsync(p => p.Id == context.Message.Id);
    }
}
