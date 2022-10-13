using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using Microsoft.Extensions.Options;
using TaskoMask.Services.Boards.Write.Domain.Entities;

namespace TaskoMask.Services.Boards.Write.Infrastructure.Data.DbContext
{

    /// <summary>
    /// 
    /// </summary>
    public class BoardWriteDbContext : MongoDbContext
    {
        public BoardWriteDbContext(IOptions<MongoDbOptions> mongoDbOptions) : base(mongoDbOptions)
        {
            Boards = GetCollection<Board>();
        }


        public IMongoCollection<Board> Boards { get; }

    }
}
