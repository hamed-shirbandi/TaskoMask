using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Boards
{
    public class BoardDeletedConsumer : BaseConsumer<BoardDeleted>
    {
        private readonly BoardReadDbContext _boardReadDbContext;


        public BoardDeletedConsumer(IInMemoryBus inMemoryBus, BoardReadDbContext boardReadDbContext) : base(inMemoryBus)
        {
            _boardReadDbContext = boardReadDbContext;
        }


        public override async Task ConsumeMessage(ConsumeContext<BoardDeleted> context)
        {
            await _boardReadDbContext.Boards.DeleteOneAsync(p => p.Id == context.Message.Id);
        }
    }
}
