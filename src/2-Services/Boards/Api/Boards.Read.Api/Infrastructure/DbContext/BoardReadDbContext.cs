using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Boards.Read.Api.Domain;

namespace TaskoMask.Services.Boards.Read.Api.Infrastructure.DbContext;

/// <summary>
///
/// </summary>
public class BoardReadDbContext : MongoDbContext
{
    #region Fields


    #endregion

    #region Ctors


    public BoardReadDbContext(IOptions<MongoDbOptions> mongoDbOptions)
        : base(mongoDbOptions)
    {
        Boards = GetCollection<Board>();
        Cards = GetCollection<Card>();
    }

    #endregion

    #region Properties

    public IMongoCollection<Board> Boards { get; }
    public IMongoCollection<Card> Cards { get; }

    #endregion
}
