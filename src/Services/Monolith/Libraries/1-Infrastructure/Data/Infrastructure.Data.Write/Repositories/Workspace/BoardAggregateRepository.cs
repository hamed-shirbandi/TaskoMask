﻿using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Domain.DomainModel.Workspace.Boards.Data;
using TaskoMask.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.Infrastructure.Data.Core.Repositories;
using TaskoMask.Infrastructure.Data.Write.DbContext;

namespace TaskoMask.Infrastructure.Data.Write.Repositories.Workspace
{
    public class BoardAggregateRepository : BaseAggregateRepository<Board>, IBoardAggregateRepository
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
}
