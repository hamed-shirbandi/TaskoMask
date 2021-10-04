using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Administration.Data;
using TaskoMask.Domain.Administration.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class OperatorRepository : UserBaseRepository<Operator>, IOperatorRepository
    {
        #region Fields


        #endregion

        #region Ctors

        public OperatorRepository(IMongoDbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        #region Public Methods

   


        #endregion

        #region Private Methods



        #endregion
       
    }
}
