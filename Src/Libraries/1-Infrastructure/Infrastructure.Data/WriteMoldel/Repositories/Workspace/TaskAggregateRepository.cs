using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.WriteModel.Workspace.Tasks.Data;
using TaskoMask.Infrastructure.Data.Common.DbContext;
using TaskoMask.Infrastructure.Data.WriteMoldel.DbContext;

namespace TaskoMask.Infrastructure.Data.WriteMoldel.Repositories.Workspace
{
    public class TaskAggregateRepository : BaseRepository<Domain.WriteModel.Workspace.Tasks.Entities.Task>, ITaskAggregateRepository
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
        public bool ExistTask(string taskId, string taskTitle)
        {
            var task =  _tasks.Find(e => e.Title.Value == taskTitle).FirstOrDefault();
            return task != null && task.Id != taskId;
        }


        #endregion

        #region Private Methods



        #endregion

    }
}
