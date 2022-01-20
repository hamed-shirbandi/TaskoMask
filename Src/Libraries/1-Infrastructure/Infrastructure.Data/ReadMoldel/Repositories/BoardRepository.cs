using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Infrastructure.Data.Common.DbContext;
using TaskoMask.Infrastructure.Data.WriteMoldel.Repositories;

namespace TaskoMask.Infrastructure.Data.ReadMoldel.Repositories
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        #region Fields

        private readonly IMongoCollection<Board> _boards;

        #endregion

        #region Ctors

        public BoardRepository(IReadDbContext dbContext) : base(dbContext)
        {
            _boards = dbContext.GetCollection<Board>();
        }

        #endregion

        #region Public Methods



        #endregion

        #region Private Methods



        #endregion

    }
}
