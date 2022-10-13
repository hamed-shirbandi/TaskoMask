using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using Microsoft.Extensions.Options;
using TaskoMask.Services.Tasks.Read.Api.Domain;

namespace TaskoMask.Services.Tasks.Read.Api.Infrastructure.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public class TaskReadDbContext : MongoDbContext
    {
        #region Fields


        #endregion

        #region Ctors


        public TaskReadDbContext(IOptions<MongoDbOptions> mongoDbOptions) : base(mongoDbOptions)
        {
            Tasks = GetCollection<Domain.Task>();
            Comments = GetCollection<Comment>();
            Activities = GetCollection<Activity>(nameof(Activities));
        }



        #endregion

        #region Properties

        public IMongoCollection<Domain.Task> Tasks { get; }
        public IMongoCollection<Comment> Comments { get; }
        public IMongoCollection<Activity> Activities { get; }

        #endregion

    }
}
