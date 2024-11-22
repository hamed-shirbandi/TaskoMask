using System.Threading.Tasks;
using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Cards;

public class BoardUpdatedConsumer : BaseConsumer<BoardUpdated>
{
    private readonly BoardReadDbContext _boardReadDbContext;

    public BoardUpdatedConsumer(IRequestDispatcher requestDispatcher, BoardReadDbContext boardReadDbContext)
        : base(requestDispatcher)
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
