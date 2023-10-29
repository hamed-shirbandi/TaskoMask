using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Entities;

namespace TaskoMask.Services.Boards.Write.Api.Infrastructure.Data.DbContext;

/// <summary>
///
/// </summary>
public class BoardWriteDbContext : MongoDbContext
{
    public BoardWriteDbContext(IOptions<MongoDbOptions> mongoDbOptions)
        : base(mongoDbOptions)
    {
        Boards = GetCollection<Board>();
    }

    public IMongoCollection<Board> Boards { get; }
}
