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
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        #region Fields

        private readonly IMongoCollection<Member> _members;

        #endregion

        #region Ctors

        public MemberRepository(IMongoDbContext dbContext) : base(dbContext)
        {
            _members = dbContext.GetCollection<Member>();
        }

        #endregion

        #region Public Methods



        #endregion

        #region Private Methods



        #endregion

    }
}
