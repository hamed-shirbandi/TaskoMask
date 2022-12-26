using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using System.Threading.Tasks;
using TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;
using TaskoMask.Services.Boards.Read.Api.Domain;

namespace TaskoMask.Services.Boards.Read.Api.Consumers.Cards
{
    public class CardAddedConsumer : BaseConsumer<CardAdded>
    {
        private readonly BoardReadDbContext _boardReadDbContext;


        public CardAddedConsumer(IInMemoryBus inMemoryBus, BoardReadDbContext boardReadDbContext) : base(inMemoryBus)
        {
            _boardReadDbContext = boardReadDbContext;
        }


        public override async Task ConsumeMessage(ConsumeContext<CardAdded> context)
        {
            var card = new Card(context.Message.Id)
            {
                Name = context.Message.Name,
                Type = context.Message.Type,
                BoardId = context.Message.BoardId,
                ProjectId = context.Message.ProjectId,
                OrganizationId= context.Message.OrganizationId,
                OwnerId = context.Message.OwnerId,
            };

            await _boardReadDbContext.Cards.InsertOneAsync(card);
        }
    }
}
