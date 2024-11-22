using System.Threading.Tasks;
using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Owners.Read.Api.Consumers.Organizations;

public class OrganizationDeletedConsumer : BaseConsumer<OrganizationDeleted>
{
    private readonly OwnerReadDbContext _ownerReadDbContext;

    public OrganizationDeletedConsumer(IRequestDispatcher requestDispatcher, OwnerReadDbContext ownerReadDbContext)
        : base(requestDispatcher)
    {
        _ownerReadDbContext = ownerReadDbContext;
    }

    public override async Task ConsumeMessage(ConsumeContext<OrganizationDeleted> context)
    {
        await _ownerReadDbContext.Organizations.DeleteOneAsync(p => p.Id == context.Message.Id);
    }
}
