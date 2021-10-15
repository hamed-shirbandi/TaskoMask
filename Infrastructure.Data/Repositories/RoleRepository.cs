using MongoDB.Bson;
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



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Role>> GetListByIdAsync(string[] selectedRolesId)
        {
            var builders = new List<FilterDefinition<Role>>();
            foreach (var roleId in selectedRolesId)
                builders.Add(Builders<Role>.Filter.Where(p => p.Id == roleId));

            var filter = Builders<Role>.Filter.Or(builders);
            return await _roles.Find(filter).ToListAsync();
        }


        #endregion

        #region Private Methods



        #endregion

    }
}
