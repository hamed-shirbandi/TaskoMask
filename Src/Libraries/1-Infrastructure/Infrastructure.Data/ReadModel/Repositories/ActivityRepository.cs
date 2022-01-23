using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
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

        #endregion

        #region Ctors

        public ActivityRepository(IReadDbContext dbContext) : base(dbContext)
        {
            _activities = dbContext.GetCollection<Activity>("Activities");
        }

        #endregion

        #region Public Methods



        #endregion

        #region Private Methods



        #endregion

    }
}
