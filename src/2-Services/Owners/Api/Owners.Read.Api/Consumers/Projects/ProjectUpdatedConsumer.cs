using System.Threading.Tasks;
using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Services;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Owners.Read.Api.Consumers.Projects;

public class ProjectUpdatedConsumer : BaseConsumer<ProjectUpdated>
{
    private readonly OwnerReadDbContext _ownerReadDbContext;

    public ProjectUpdatedConsumer(IRequestDispatcher requestDispatcher, OwnerReadDbContext ownerReadDbContext)
        : base(requestDispatcher)
    {
        _ownerReadDbContext = ownerReadDbContext;
    }

    public override async Task ConsumeMessage(ConsumeContext<ProjectUpdated> context)
    {
        var project = await _ownerReadDbContext.Projects.Find(e => e.Id == context.Message.Id).FirstOrDefaultAsync();

        project.Name = context.Message.Name;
        project.Description = context.Message.Description;
        project.SetAsUpdated();

        await _ownerReadDbContext.Projects.ReplaceOneAsync(p => p.Id == project.Id, project, new ReplaceOptions() { IsUpsert = false });
    }
}
