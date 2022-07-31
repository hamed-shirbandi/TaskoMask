using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.DataModel.Data;
using TaskoMask.Domain.DataModel.Entities;
using TaskoMask.Infrastructure.Data.Core.Repositories;
using TaskoMask.Infrastructure.Data.Read.DbContext;

namespace TaskoMask.Infrastructure.Data.Read.Repositories
{
    public class ActivityRepository : BaseRepository<Activity>, IActivityRepository
    {
        #region Fields

        private readonly IMongoCollection<Activity> _activities;
        private const string activityCollectionName = "Activities";
        #endregion

        #region Ctors

        public ActivityRepository(IReadDbContext dbContext) : base(dbContext, activityCollectionName)
        {
            _activities = dbContext.GetCollection<Activity>(activityCollectionName);
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Activity>> GetListByTaskIdAsync(string taskId)
        {
            return await _activities.AsQueryable()
                .Where(o => o.TaskId == taskId)
                .OrderByDescending(o=>o.CreationTime.CreateDateTime)
                .ToListAsync();
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
