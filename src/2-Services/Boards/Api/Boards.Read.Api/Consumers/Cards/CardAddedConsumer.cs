using System.Threading.Tasks;
using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Boards.Read.Api.Domain;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Cards;

public class CardAddedConsumer : BaseConsumer<CardAdded>
{
    private readonly BoardReadDbContext _boardReadDbContext;

    public CardAddedConsumer(IRequestDispatcher requestDispatcher, BoardReadDbContext boardReadDbContext)
        : base(requestDispatcher)
    {
        _boardReadDbContext = boardReadDbContext;
    }

    public override async Task ConsumeMessage(ConsumeContext<CardAdded> context)
    {
        var board = await _boardReadDbContext.Boards.Find(b => b.Id == context.Message.BoardId).FirstOrDefaultAsync();

        var card = new Card(context.Message.Id)
        {
            Name = context.Message.Name,
            Type = context.Message.Type,
            BoardId = context.Message.BoardId,
            ProjectId = board.ProjectId,
            OrganizationId = board.OrganizationId,
            OwnerId = board.OwnerId,
        };

        await _boardReadDbContext.Cards.InsertOneAsync(card);
    }
}
