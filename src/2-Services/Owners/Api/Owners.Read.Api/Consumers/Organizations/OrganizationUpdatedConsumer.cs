using System.Threading.Tasks;
using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Owners.Read.Api.Consumers.Organizations;

public class OrganizationUpdatedConsumer : BaseConsumer<OrganizationUpdated>
{
    private readonly OwnerReadDbContext _ownerReadDbContext;

    public OrganizationUpdatedConsumer(IRequestDispatcher requestDispatcher, OwnerReadDbContext ownerReadDbContext)
        : base(requestDispatcher)
    {
        _ownerReadDbContext = ownerReadDbContext;
    }

    public override async Task ConsumeMessage(ConsumeContext<OrganizationUpdated> context)
    {
        var organization = await _ownerReadDbContext.Organizations.Find(e => e.Id == context.Message.Id).FirstOrDefaultAsync();

        organization.Name = context.Message.Name;
        organization.Description = context.Message.Description;
        organization.SetAsUpdated();

        await _ownerReadDbContext.Organizations.ReplaceOneAsync(
            p => p.Id == organization.Id,
            organization,
            new ReplaceOptions() { IsUpsert = false }
        );
    }
}
