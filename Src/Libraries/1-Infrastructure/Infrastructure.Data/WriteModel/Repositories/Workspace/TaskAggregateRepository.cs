using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Data;
using TaskoMask.Infrastructure.Data.Common.Repositories;
using TaskoMask.Infrastructure.Data.WriteModel.DbContext;

namespace TaskoMask.Infrastructure.Data.WriteModel.Repositories.Workspace
{
    public class TaskAggregateRepository : BaseAggregateRepository<Domain.WriteModel.Workspace.Tasks.Entities.Task>, ITaskAggregateRepository
    {
        #region Fields

        private readonly IMongoCollection<Domain.WriteModel.Workspace.Tasks.Entities.Task> _tasks;

        #endregion

        #region Ctors

        public TaskAggregateRepository(IWriteDbContext dbContext) : base(dbContext)
        {
            _tasks = dbContext.GetCollection<Domain.WriteModel.Workspace.Tasks.Entities.Task>();
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


        #endregion

        #region Private Methods



        #endregion

    }
}
