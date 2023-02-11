using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Cards
{
    public class CardUpdatedConsumer : BaseConsumer<CardUpdated>
    {
        private readonly BoardReadDbContext _boardReadDbContext;


        public CardUpdatedConsumer(IInMemoryBus inMemoryBus, BoardReadDbContext boardReadDbContext) : base(inMemoryBus)
        {
            _boardReadDbContext = boardReadDbContext;
        }


        public override async Task ConsumeMessage(ConsumeContext<CardUpdated> context)
        {
            var card = await _boardReadDbContext.Cards.Find(e => e.Id == context.Message.Id).FirstOrDefaultAsync();

            card.Name = context.Message.Name;
            card.Type = context.Message.Type;
            card.SetAsUpdated();

            await _boardReadDbContext.Cards.ReplaceOneAsync(p => p.Id == card.Id, card, new ReplaceOptions() { IsUpsert = false });
        }
    }
}
