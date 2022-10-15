using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using Microsoft.Extensions.Options;
using TaskoMask.Services.Tasks.Write.Domain.Entities;

namespace TaskoMask.Services.Tasks.Write.Infrastructure.Data.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public class TaskWriteDbContext : MongoDbContext
    {
        public TaskWriteDbContext(IOptions<MongoDbOptions> mongoDbOptions) : base(mongoDbOptions)
        {
            Tasks = GetCollection<Task>();
        }


        public IMongoCollection<Task> Tasks { get; }

    }
}
