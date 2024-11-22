using System.Threading.Tasks;
using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Boards;

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
        var board = await _boardReadDbContext.Boards.Find(e => e.Id == context.Message.Id).FirstOrDefaultAsync();

        board.Name = context.Message.Name;
        board.Description = context.Message.Description;
        board.SetAsUpdated();

        await _boardReadDbContext.Boards.ReplaceOneAsync(p => p.Id == board.Id, board, new ReplaceOptions() { IsUpsert = false });
    }
}
