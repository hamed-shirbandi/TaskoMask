using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Boards
{
    public class ProjectUpdatedConsumer : BaseConsumer<ProjectUpdated>
    {
        private readonly BoardReadDbContext _boardReadDbContext;


        public ProjectUpdatedConsumer(IInMemoryBus inMemoryBus, BoardReadDbContext boardReadDbContext) : base(inMemoryBus)
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
}
