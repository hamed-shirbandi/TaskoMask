using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Infrastructure.Data.Common.Contracts;
using TaskoMask.Infrastructure.Data.WriteMoldel.Repositories;

namespace TaskoMask.Infrastructure.Data.ReadMoldel.Repositories
{
    public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
    {
        #region Fields

        private readonly IMongoCollection<Owner> _owners;

        #endregion

        #region Ctors

        public OwnerRepository(IMongoDbContext dbContext) : base(dbContext)
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
