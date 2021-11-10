using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Domain.Administration.Data;
using TaskoMask.Domain.Administration.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class OperatorRepository : UserRepository<Operator>, IOperatorRepository
    {
        #region Fields


        #endregion

        #region Ctors

        public OperatorRepository(IMongoDbContext dbContext) : base(dbContext)
        {
        }

        #endregion

        #region Public Methods

   
        /// <summary>
        /// 
        /// </summary>
        public async Task<long> CountByRoleIdAsync(string roleId)
        {
            return await _users.CountDocumentsAsync(e => e.RolesId.Contains(roleId));
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Operator>> GetListByRoleIdAsync(string roleId)
        {
            return await _users.Find(u => u.RolesId.Contains(roleId)).ToListAsync();
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
