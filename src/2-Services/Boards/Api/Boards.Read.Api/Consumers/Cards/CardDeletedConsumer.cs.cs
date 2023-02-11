using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Cards
{
    public class CardDeletedConsumer : BaseConsumer<CardDeleted>
    {
        private readonly BoardReadDbContext _boardReadDbContext;


        public CardDeletedConsumer(IInMemoryBus inMemoryBus, BoardReadDbContext boardReadDbContext) : base(inMemoryBus)
        {
            _boardReadDbContext = boardReadDbContext;
        }


        public override async Task ConsumeMessage(ConsumeContext<CardDeleted> context)
        {
            await _boardReadDbContext.Cards.DeleteOneAsync(p => p.Id == context.Message.Id);
        }
    }
}
