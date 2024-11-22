using System.Threading.Tasks;
using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Boards;

public class BoardDeletedConsumer : BaseConsumer<BoardDeleted>
{
    private readonly BoardReadDbContext _boardReadDbContext;

    public BoardDeletedConsumer(IRequestDispatcher requestDispatcher, BoardReadDbContext boardReadDbContext)
        : base(requestDispatcher)
    {
        _boardReadDbContext = boardReadDbContext;
    }

    public override async Task ConsumeMessage(ConsumeContext<BoardDeleted> context)
    {
        await _boardReadDbContext.Boards.DeleteOneAsync(p => p.Id == context.Message.Id);
    }
}
