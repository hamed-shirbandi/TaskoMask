using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Infrastructure.Data.Common.Repositories;
using TaskoMask.Infrastructure.Data.ReadModel.DbContext;

namespace TaskoMask.Infrastructure.Data.ReadModel.Repositories
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
