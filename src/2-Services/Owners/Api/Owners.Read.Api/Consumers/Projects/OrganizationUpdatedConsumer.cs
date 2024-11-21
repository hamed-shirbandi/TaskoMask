﻿using System.Threading.Tasks;
using MassTransit;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Web.MVC.Consumers;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;

namespace TaskoMask.Services.Owners.Read.Api.Consumers.Projects;

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
        var projetcs = await _ownerReadDbContext.Projects.Find(e => e.OrganizationId == context.Message.Id).ToListAsync();

        foreach (var projetc in projetcs)
        {
            projetc.OrganizationName = context.Message.Name;
            projetc.SetAsUpdated();
            await _ownerReadDbContext.Projects.ReplaceOneAsync(p => p.Id == projetc.Id, projetc, new ReplaceOptions() { IsUpsert = false });
        }
    }
}
