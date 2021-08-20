using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class ManagerRepository : UserBaseRepository<Manager>, IManagerRepository
    {
        #region Fields


        #endregion

        #region Ctors

        public ManagerRepository(IMainDbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        #region Public Methods




        #endregion

        #region Private Methods



        #endregion

    }
}
