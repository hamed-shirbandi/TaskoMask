using System.Threading.Tasks;
using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Owners.Read.Api.Consumers.Owners;

public class OwnerUpdatingProfileCompletedConsumer : BaseConsumer<OwnerUpdatingProfileCompleted>
{
    private readonly OwnerReadDbContext _ownerReadDbContext;

    public OwnerUpdatingProfileCompletedConsumer(IRequestDispatcher requestDispatcher, OwnerReadDbContext ownerReadDbContext)
        : base(requestDispatcher)
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
