using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.DataModel.Data;
using TaskoMask.Domain.DataModel.Entities;
using TaskoMask.Infrastructure.Data.Core.Repositories;
using TaskoMask.Infrastructure.Data.Read.DbContext;

namespace TaskoMask.Infrastructure.Data.Read.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        #region Fields

        private readonly IMongoCollection<Comment> _comments;

        #endregion

        #region Ctors

        public CommentRepository(IReadDbContext dbContext) : base(dbContext)
        {
            _comments = dbContext.GetCollection<Comment>();
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Comment>> GetListByTaskIdAsync(string taskId)
        {
            return await _comments.AsQueryable().Where(o => o.TaskId == taskId ).ToListAsync();
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
