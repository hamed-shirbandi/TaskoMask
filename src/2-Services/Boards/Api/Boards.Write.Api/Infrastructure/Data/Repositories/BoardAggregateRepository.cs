using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Data;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Entities;
using TaskoMask.Services.Boards.Write.Api.Infrastructure.Data.DbContext;

namespace TaskoMask.Services.Boards.Write.Api.Infrastructure.Data.Repositories;

public class BoardAggregateRepository : MongoDbBaseAggregateRepository<Board>, IBoardAggregateRepository
{
    #region Fields

    private readonly IMongoCollection<Board> _boards;

    #endregion

    #region Ctors

    public BoardAggregateRepository(BoardWriteDbContext dbContext)
        : base(dbContext)
    {
        _boards = dbContext.GetCollection<Board>();
    }

    #endregion

    #region Public Methods



    /// <summary>
    ///
    /// </summary>
    public bool ExistBoard(string boardId, string projectId, string boardName)
    {
        var board = _boards.Find(e => e.ProjectId.Value == projectId && e.Name.Value == boardName).FirstOrDefault();
        return board != null && board.Id != boardId;
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Board> GetByCardIdAsync(string cardId)
    {
        return await _boards.Find(e => e.Cards.Any(c => c.Id == cardId)).FirstOrDefaultAsync();
    }

    #endregion

    #region Private Methods



    #endregion
}
