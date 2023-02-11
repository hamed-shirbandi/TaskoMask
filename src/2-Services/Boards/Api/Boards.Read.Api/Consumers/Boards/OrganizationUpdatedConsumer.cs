using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using System.Threading.Tasks;
using MongoDB.Driver;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Boards
{
    public class OrganizationUpdatedConsumer : BaseConsumer<OrganizationUpdated>
    {
        private readonly BoardReadDbContext _boardReadDbContext;


        public OrganizationUpdatedConsumer(IInMemoryBus inMemoryBus, BoardReadDbContext boardReadDbContext) : base(inMemoryBus)
        {
            _boardReadDbContext = boardReadDbContext;
        }


        public override async Task ConsumeMessage(ConsumeContext<OrganizationUpdated> context)
        {
            var boards = await _boardReadDbContext.Boards.Find(e => e.ProjectId == context.Message.Id).ToListAsync();

            foreach (var board in boards)
            {
                board.OrganizationName = context.Message.Name;
                board.SetAsUpdated();
                await _boardReadDbContext.Boards.ReplaceOneAsync(p => p.Id == board.Id, board, new ReplaceOptions() { IsUpsert = false });
            }
        }
    }
}
