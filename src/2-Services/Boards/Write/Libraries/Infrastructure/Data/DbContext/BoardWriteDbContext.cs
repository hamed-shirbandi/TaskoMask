using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using Microsoft.Extensions.Options;

namespace TaskoMask.Services.Boards.Write.Infrastructure.Data.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public class BoardWriteDbContext : MongoDbContext
    {
        public BoardWriteDbContext(IOptions<MongoDbOptions> mongoDbOptions) : base(mongoDbOptions)
        {
            //Boards = GetCollection<Board>();
        }


       // public IMongoCollection<Board> Boards { get; }

    }
}
