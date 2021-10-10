using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Administration.Data;
using TaskoMask.Domain.Administration.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        #region Fields

        private readonly IMongoCollection<Role> _roles;

        #endregion

        #region Ctors

        public RoleRepository(IMongoDbContext dbContext) : base(dbContext)
        {
            _roles = dbContext.GetCollection<Role>(); 
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> ExistByNameAsync(string id, string name)
        {
            var role = await _roles.Find(e => e.Name == name).FirstOrDefaultAsync();
            return role != null && role.Id != id;
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
