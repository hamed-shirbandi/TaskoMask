using System.Threading.Tasks;
using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Tasks.Read.Api.Consumers.Comments;

public class CommentDeletedConsumer : BaseConsumer<CommentDeleted>
{
    private readonly TaskReadDbContext _taskReadDbContext;

    public CommentDeletedConsumer(IRequestDispatcher requestDispatcher, TaskReadDbContext taskReadDbContext)
        : base(requestDispatcher)
    {
        _taskReadDbContext = taskReadDbContext;
    }

    public override async Task ConsumeMessage(ConsumeContext<CommentDeleted> context)
    {
        await _taskReadDbContext.Comments.DeleteOneAsync(p => p.Id == context.Message.Id);
    }
}
