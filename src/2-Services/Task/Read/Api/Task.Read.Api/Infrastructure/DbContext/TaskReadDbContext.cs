using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using Microsoft.Extensions.Options;

namespace TaskoMask.Services.Task.Read.Api.Infrastructure.DbContext
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
            //Owners = GetCollection<Owner>();
            //Tasks = GetCollection<Task>();
            //Tasks = GetCollection<Task>();
        }



        #endregion

        #region Properties

        //public IMongoCollection<Owner> Owners { get; }
        //public IMongoCollection<Task> Tasks { get; }
        //public IMongoCollection<Task> Tasks { get; }

        #endregion

    }
}
