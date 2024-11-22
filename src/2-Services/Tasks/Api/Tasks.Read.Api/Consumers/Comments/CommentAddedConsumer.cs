using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Tasks.Read.Api.Domain;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Tasks.Read.Api.Consumers.Comments;

public class CommentAddedConsumer : BaseConsumer<CommentAdded>
{
    private readonly TaskReadDbContext _taskReadDbContext;

    public CommentAddedConsumer(IRequestDispatcher requestDispatcher, TaskReadDbContext taskReadDbContext)
        : base(requestDispatcher)
    {
        _taskReadDbContext = taskReadDbContext;
    }

    public override async System.Threading.Tasks.Task ConsumeMessage(ConsumeContext<CommentAdded> context)
    {
        var task = await _taskReadDbContext.Tasks.Find(b => b.Id == context.Message.TaskId).FirstOrDefaultAsync();

        var comment = new Comment(context.Message.Id) { Content = context.Message.Content, TaskId = context.Message.TaskId };

        await _taskReadDbContext.Comments.InsertOneAsync(comment);
    }
}
