using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using System.Threading.Tasks;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;
using TaskoMask.Services.Boards.Read.Api.Domain;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;

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
            //TODO get from owner read service via rpc call
            var project = new GetProjectDto();

            var board = new Board(context.Message.Id)
            {
                Name = context.Message.Name,
                Description = context.Message.Description,
                ProjectId = context.Message.ProjectId,
                OrganizationId= project.OrganizationId,
                OrganizationName = project.OrganizationName,
                ProjectName = project.Name,
                OwnerId = project.OwnerId,
            };

            await _boardReadDbContext.Boards.InsertOneAsync(board);
        }
    }
}
