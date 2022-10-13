using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using Microsoft.Extensions.Options;
using TaskoMask.Services.Owners.Write.Domain.Entities;

namespace TaskoMask.Services.Owners.Write.Infrastructure.Data.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public class OwnerWriteDbContext : MongoDbContext
    {
        public OwnerWriteDbContext(IOptions<MongoDbOptions> mongoDbOptions) : base(mongoDbOptions)
        {
            Owners = GetCollection<Owner>();
        }


        public IMongoCollection<Owner> Owners { get; }

    }
}
