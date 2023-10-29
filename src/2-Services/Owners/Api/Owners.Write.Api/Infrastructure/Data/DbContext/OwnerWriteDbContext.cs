using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Entities;

namespace TaskoMask.Services.Owners.Write.Api.Infrastructure.Data.DbContext;

/// <summary>
///
/// </summary>
public class OwnerWriteDbContext : MongoDbContext
{
    public OwnerWriteDbContext(IOptions<MongoDbOptions> mongoDbOptions)
        : base(mongoDbOptions)
    {
        Owners = GetCollection<Owner>();
    }

    public IMongoCollection<Owner> Owners { get; }
}
