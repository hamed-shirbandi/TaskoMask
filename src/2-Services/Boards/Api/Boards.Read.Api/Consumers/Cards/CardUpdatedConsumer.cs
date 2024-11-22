using System.Threading.Tasks;
using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Cards;

public class CardUpdatedConsumer : BaseConsumer<CardUpdated>
{
    private readonly BoardReadDbContext _boardReadDbContext;

    public CardUpdatedConsumer(IRequestDispatcher requestDispatcher, BoardReadDbContext boardReadDbContext)
        : base(requestDispatcher)
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
