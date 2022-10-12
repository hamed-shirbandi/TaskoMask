using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DbContext;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Read.Repositories
{
    public class ActivityRepository : MongoDbBaseRepository<Activity>, IActivityRepository
    {
        #region Fields

        private readonly IMongoCollection<Activity> _activities;
        private const string activityCollectionName = nameof(ReadDbContext.Activities);
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
