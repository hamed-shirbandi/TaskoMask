using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Team.Data;
using TaskoMask.Domain.Team.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class MemberRepository : UserRepository<Member>, IMemberRepository
    {
        #region Fields


        #endregion

        #region Ctors

        public MemberRepository(IMongoDbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        #region Public Methods




        #endregion

        #region Private Methods



        #endregion

    }
}
