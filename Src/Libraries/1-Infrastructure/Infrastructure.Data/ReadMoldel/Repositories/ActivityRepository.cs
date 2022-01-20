using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Infrastructure.Data.Common.DbContext;
using TaskoMask.Infrastructure.Data.WriteMoldel.Repositories;

namespace TaskoMask.Infrastructure.Data.ReadMoldel.Repositories
{
    public class ActivityRepository : BaseRepository<Activity>, IActivityRepository
    {
        #region Fields

        private readonly IMongoCollection<Activity> _activities;

        #endregion

        #region Ctors

        public ActivityRepository(IReadDbContext dbContext) : base(dbContext)
        {
            _activities = dbContext.GetCollection<Activity>();
        }

        #endregion

        #region Public Methods



        #endregion

        #region Private Methods



        #endregion

    }
}
