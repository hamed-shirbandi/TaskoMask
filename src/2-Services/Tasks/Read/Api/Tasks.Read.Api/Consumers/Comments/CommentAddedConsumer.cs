using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;
using MongoDB.Driver;
using TaskoMask.Services.Tasks.Read.Api.Domain;

namespace TaskoMask.Services.Tasks.Read.Api.Consumers.Comments
{
    public class CommentAddedConsumer : BaseConsumer<CommentAdded>
    {
        private readonly TaskReadDbContext _taskReadDbContext;


        public CommentAddedConsumer(IInMemoryBus inMemoryBus, TaskReadDbContext taskReadDbContext) : base(inMemoryBus)
        {
            _taskReadDbContext = taskReadDbContext;
        }


        public override async System.Threading.Tasks.Task ConsumeMessage(ConsumeContext<CommentAdded> context)
        {
            var task = await _taskReadDbContext.Tasks.Find(b => b.Id == context.Message.TaskId).FirstOrDefaultAsync();
           
            var comment = new Comment(context.Message.Id)
            {
                Content = context.Message.Content,
                TaskId = context.Message.TaskId,
            };

            await _taskReadDbContext.Comments.InsertOneAsync(comment);
        }
    }
}
