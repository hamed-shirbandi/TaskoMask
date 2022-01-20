using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Data;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;
using TaskoMask.Infrastructure.Data.Common.DbContext;

namespace TaskoMask.Infrastructure.Data.WriteMoldel.Repositories.Workspace
{
    public class OwnerAggregateRepository : BaseRepository<Owner>, IOwnerAggregateRepository
    {
        #region Fields

        protected readonly IMongoCollection<Owner> _owners;


        #endregion

        #region Ctors

        public OwnerAggregateRepository(IWriteDbContext dbContext) : base(dbContext)
        {
            _owners = dbContext.GetCollection<Owner>();

        }

        #endregion

        #region Public Methods



        #endregion

        #region Private Methods



        #endregion

    }
}
