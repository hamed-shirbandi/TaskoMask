using System.Threading.Tasks;
using MassTransit;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Owners.Read.Api.Domain;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Owners.Read.Api.Consumers.Organizations;

public class OrganizationAddedConsumer : BaseConsumer<OrganizationAdded>
{
    private readonly OwnerReadDbContext _ownerReadDbContext;

    public OrganizationAddedConsumer(IRequestDispatcher requestDispatcher, OwnerReadDbContext ownerReadDbContext)
        : base(requestDispatcher)
    {
        _ownerReadDbContext = ownerReadDbContext;
    }

    public override async Task ConsumeMessage(ConsumeContext<OrganizationAdded> context)
    {
        var organization = new Organization(context.Message.Id)
        {
            Name = context.Message.Name,
            Description = context.Message.Description,
            OwnerId = context.Message.OwnerId,
        };

        await _ownerReadDbContext.Organizations.InsertOneAsync(organization);
    }
}
