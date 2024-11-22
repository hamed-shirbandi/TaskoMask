using System.Threading.Tasks;
using MassTransit;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Owners.Read.Api.Domain;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Owners.Read.Api.Consumers.Projects;

public class ProjectAddedConsumer : BaseConsumer<ProjectAdded>
{
    private readonly OwnerReadDbContext _ownerReadDbContext;

    public ProjectAddedConsumer(IRequestDispatcher requestDispatcher, OwnerReadDbContext ownerReadDbContext)
        : base(requestDispatcher)
    {
        _ownerReadDbContext = ownerReadDbContext;
    }

    public override async Task ConsumeMessage(ConsumeContext<ProjectAdded> context)
    {
        var project = new Project(context.Message.Id)
        {
            Name = context.Message.Name,
            Description = context.Message.Description,
            OrganizationId = context.Message.OrganizationId,
            OrganizationName = context.Message.OrganizationName,
            OwnerId = context.Message.OwnerId,
        };

        await _ownerReadDbContext.Projects.InsertOneAsync(project);
    }
}
