using MassTransit;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace TaskoMask.Services.Owners.Read.Api.Consumers.Owners
{
    public class OwnerUpdatingProfileCompletedConsumer : BaseConsumer<OwnerUpdatingProfileCompleted>
    {
        private readonly OwnerReadDbContext _ownerReadDbContext;


        public OwnerUpdatingProfileCompletedConsumer(IInMemoryBus inMemoryBus, OwnerReadDbContext ownerReadDbContext) : base(inMemoryBus)
        {
            _ownerReadDbContext = ownerReadDbContext;
        }


        public override async Task ConsumeMessage(ConsumeContext<OwnerUpdatingProfileCompleted> context)
        {
            var owner = await _ownerReadDbContext.Owners.Find(e => e.Id == context.Message.Id).FirstOrDefaultAsync();

            owner.Email = context.Message.Email;
            owner.DisplayName = context.Message.DisplayName;
            owner.SetAsUpdated();

            await _ownerReadDbContext.Owners.ReplaceOneAsync(p => p.Id == owner.Id, owner, new ReplaceOptions() { IsUpsert = false });
        }
    }
}
