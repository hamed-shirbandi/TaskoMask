using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using Microsoft.Extensions.Options;

namespace TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public class BoardReadDbContext : MongoDbContext
    {
        #region Fields


        #endregion

        #region Ctors


        public BoardReadDbContext(IOptions<MongoDbOptions> mongoDbOptions) : base(mongoDbOptions)
        {
            //Owners = GetCollection<Owner>();
            //Boards = GetCollection<Board>();
            //Tasks = GetCollection<Task>();
        }



        #endregion

        #region Properties

        //public IMongoCollection<Owner> Owners { get; }
        //public IMongoCollection<Board> Boards { get; }
        //public IMongoCollection<Task> Tasks { get; }

        #endregion

    }
}
