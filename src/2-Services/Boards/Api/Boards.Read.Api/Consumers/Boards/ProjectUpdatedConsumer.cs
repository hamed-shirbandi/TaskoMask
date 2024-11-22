using System.Threading.Tasks;
using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Boards;

public class ProjectUpdatedConsumer : BaseConsumer<ProjectUpdated>
{
    private readonly BoardReadDbContext _boardReadDbContext;

    public ProjectUpdatedConsumer(IRequestDispatcher requestDispatcher, BoardReadDbContext boardReadDbContext)
        : base(requestDispatcher)
    {
        _boardReadDbContext = boardReadDbContext;
    }

    public override async Task ConsumeMessage(ConsumeContext<ProjectUpdated> context)
    {
        var boards = await _boardReadDbContext.Boards.Find(e => e.ProjectId == context.Message.Id).ToListAsync();

        foreach (var board in boards)
        {
            board.ProjectName = context.Message.Name;
            board.SetAsUpdated();
            await _boardReadDbContext.Boards.ReplaceOneAsync(p => p.Id == board.Id, board, new ReplaceOptions() { IsUpsert = false });
        }
    }
}
