using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Cards
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
            var cards = await _boardReadDbContext.Cards.Find(e => e.BoardId == context.Message.Id).ToListAsync();

            foreach (var card in cards)
            {
                card.BoardName = context.Message.Name;
                card.SetAsUpdated();
                await _boardReadDbContext.Cards.ReplaceOneAsync(p => p.Id == card.Id, card, new ReplaceOptions() { IsUpsert = false });
            }
        }
    }
}
