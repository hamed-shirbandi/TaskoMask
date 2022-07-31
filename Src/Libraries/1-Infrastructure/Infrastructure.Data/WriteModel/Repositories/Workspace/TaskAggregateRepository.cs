using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Domain.DomainModel.Workspace.Tasks.Data;
using TaskoMask.Infrastructure.Data.Common.Repositories;
using TaskoMask.Infrastructure.Data.WriteModel.DbContext;

namespace TaskoMask.Infrastructure.Data.WriteModel.Repositories.Workspace
{
    public class TaskAggregateRepository : BaseAggregateRepository<Domain.DomainModel.Workspace.Tasks.Entities.Task>, ITaskAggregateRepository
    {
        #region Fields

        private readonly IMongoCollection<Domain.DomainModel.Workspace.Tasks.Entities.Task> _tasks;

        #endregion

        #region Ctors

        public TaskAggregateRepository(IWriteDbContext dbContext) : base(dbContext)
        {
            _tasks = dbContext.GetCollection<Domain.DomainModel.Workspace.Tasks.Entities.Task>();
        }

        #endregion

        #region Public Methods




        /// <summary>
        /// 
        /// </summary>
        public bool ExistTask(string taskId, string boardId, string taskTitle)
        {
            var task = _tasks.Find(e => e.BoardId.Value == boardId && e.Title.Value == taskTitle && e.IsDeleted==false).FirstOrDefault();
            return task != null && task.Id != taskId;
        }



        /// <summary>
        /// 
        /// </summary>
        public long CountByBoardId(string boardId)
        {
            return _tasks.CountDocuments(t=>t.BoardId.Value==boardId &&t.IsDeleted==false);
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task<Domain.DomainModel.Workspace.Tasks.Entities.Task> GetByCommentIdAsync(string commentId)
        {
            return await _tasks.Find(e => e.Comments.Any(c => c.Id == commentId)).FirstOrDefaultAsync();
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
