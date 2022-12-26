using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using System.Threading.Tasks;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;
using TaskoMask.Services.Boards.Read.Api.Domain;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Boards
{
    public class BoardAddedConsumer : BaseConsumer<BoardAdded>
    {
        private readonly BoardReadDbContext _boardReadDbContext;


        public BoardAddedConsumer(IInMemoryBus inMemoryBus, BoardReadDbContext boardReadDbContext) : base(inMemoryBus)
        {
            _boardReadDbContext = boardReadDbContext;
        }


        public override async Task ConsumeMessage(ConsumeContext<BoardAdded> context)
        {
            var board = new Board(context.Message.Id)
            {
                Name = context.Message.Name,
                Description = context.Message.Description,
                ProjectId = context.Message.ProjectId,
                OrganizationId= context.Message.OrganizationId,
                OrganizationName = context.Message.OrganizationName,
                ProjectName = context.Message.ProjectName,
                OwnerId = context.Message.OwnerId,
            };

            await _boardReadDbContext.Boards.InsertOneAsync(board);
        }
    }
}
