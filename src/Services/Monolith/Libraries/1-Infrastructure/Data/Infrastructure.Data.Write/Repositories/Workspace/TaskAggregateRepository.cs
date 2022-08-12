﻿using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Linq;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Data;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Entities;
using TaskoMask.Infrastructure.Data.Write.DbContext;

namespace TaskoMask.Infrastructure.Data.Write.Repositories.Workspace
{
    public class TaskAggregateRepository : BaseAggregateRepository<Task>, ITaskAggregateRepository
    {
        #region Fields

        private readonly IMongoCollection<Task> _tasks;

        #endregion

        #region Ctors

        public TaskAggregateRepository(IWriteDbContext dbContext) : base(dbContext)
        {
            _tasks = dbContext.GetCollection<Task>();
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public bool ExistTask(string taskId, string boardId, string taskTitle)
        {
            var task = _tasks.Find(e => e.BoardId.Value == boardId && e.Title.Value == taskTitle).FirstOrDefault();
            return task != null && task.Id != taskId;
        }



        /// <summary>
        /// 
        /// </summary>
        public long CountByBoardId(string boardId)
        {
            return _tasks.CountDocuments(t=>t.BoardId.Value==boardId);
        }




        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task<Task> GetByCommentIdAsync(string commentId)
        {
            return await _tasks.Find(e => e.Comments.Any(c => c.Id == commentId)).FirstOrDefaultAsync();
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
