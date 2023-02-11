using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Boards
{
    public class BoardUpdatedConsumer : BaseConsumer<BoardUpdated>
    {
        private readonly BoardReadDbContext _boardReadDbContext;


        public BoardUpdatedConsumer(IInMemoryBus inMemoryBus, BoardReadDbContext boardReadDbContext) : base(inMemoryBus)
        {
            _boardReadDbContext = boardReadDbContext;
        }


        public override async Task ConsumeMessage(ConsumeContext<BoardUpdated> context)
        {
            var board = await _boardReadDbContext.Boards.Find(e => e.Id == context.Message.Id).FirstOrDefaultAsync();

            board.Name = context.Message.Name;
            board.Description = context.Message.Description;
            board.SetAsUpdated();

            await _boardReadDbContext.Boards.ReplaceOneAsync(p => p.Id == board.Id, board, new ReplaceOptions() { IsUpsert = false });
        }
    }
}
