using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Data;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;
using TaskoMask.Infrastructure.Data.Common.DbContext;

namespace TaskoMask.Infrastructure.Data.WriteMoldel.Repositories.Workspace
{
    public class BoardAggregateRepository : BaseRepository<Board>, IBoardAggregateRepository
    {
        #region Fields

        private readonly IMongoCollection<Board> _boards;

        #endregion

        #region Ctors

        public BoardAggregateRepository(IWriteDbContext dbContext) : base(dbContext)
        {
            _boards = dbContext.GetCollection<Board>(); 
        }


        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public bool ExistBoard(string boardId, string boardName)
        {
            var board = _boards.Find(e => e.Name.Value == boardName).FirstOrDefault();
            return board != null && board.Id != boardId;
        }


        #endregion

        #region Private Methods



        #endregion

    }
}
