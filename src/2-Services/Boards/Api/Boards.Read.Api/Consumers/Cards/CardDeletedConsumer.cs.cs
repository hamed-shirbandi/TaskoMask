using System.Threading.Tasks;
using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Cards;

public class CardDeletedConsumer : BaseConsumer<CardDeleted>
{
    private readonly BoardReadDbContext _boardReadDbContext;

    public CardDeletedConsumer(IRequestDispatcher requestDispatcher, BoardReadDbContext boardReadDbContext)
        : base(requestDispatcher)
    {
        _boardReadDbContext = boardReadDbContext;
    }

    public override async Task ConsumeMessage(ConsumeContext<CardDeleted> context)
    {
        await _boardReadDbContext.Cards.DeleteOneAsync(p => p.Id == context.Message.Id);
    }
}
