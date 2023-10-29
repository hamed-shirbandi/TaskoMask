using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Tasks.Write.Api.Domain.Tasks.Entities;

namespace TaskoMask.Services.Tasks.Write.Api.Infrastructure.Data.DbContext;

/// <summary>
///
/// </summary>
public class TaskWriteDbContext : MongoDbContext
{
    public TaskWriteDbContext(IOptions<MongoDbOptions> mongoDbOptions)
        : base(mongoDbOptions)
    {
        Tasks = GetCollection<Task>();
    }

    public IMongoCollection<Task> Tasks { get; }
}
