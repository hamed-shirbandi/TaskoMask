using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TaskoMask.Services.Tasks.Read.Api.Consumers.Comments
{
    public class CommentUpdatedConsumer : BaseConsumer<CommentUpdated>
    {
        private readonly TaskReadDbContext _taskReadDbContext;


        public CommentUpdatedConsumer(IInMemoryBus inMemoryBus, TaskReadDbContext taskReadDbContext) : base(inMemoryBus)
        {
            _taskReadDbContext = taskReadDbContext;
        }


        public override async Task ConsumeMessage(ConsumeContext<CommentUpdated> context)
        {
            var comment = await _taskReadDbContext.Comments.Find(e => e.Id == context.Message.Id).FirstOrDefaultAsync();

            comment.Content = context.Message.Content;
            comment.SetAsUpdated();

            await _taskReadDbContext.Comments.ReplaceOneAsync(p => p.Id == comment.Id, comment, new ReplaceOptions() { IsUpsert = false });
        }
    }
}
