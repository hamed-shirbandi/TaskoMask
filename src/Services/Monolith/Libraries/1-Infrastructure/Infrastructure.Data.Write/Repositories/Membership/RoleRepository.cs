﻿using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Domain.DomainModel.Membership.Data;
using TaskoMask.Domain.DomainModel.Membership.Entities;
using TaskoMask.Infrastructure.Data.Core.Repositories;
using TaskoMask.Infrastructure.Data.Write.DbContext;

namespace TaskoMask.Infrastructure.Data.Write.Repositories.Membership
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        #region Fields

        private readonly IMongoCollection<Role> _roles;

        #endregion

        #region Ctors

        public RoleRepository(IWriteDbContext dbContext) : base(dbContext)
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
        public async Task<IEnumerable<Role>> GetListByIdsAsync(string[] selectedRolesId)
        {

            if (selectedRolesId == null || selectedRolesId.Any() == false)
                return new List<Role>();

            var builders = new List<FilterDefinition<Role>>();
            foreach (var roleId in selectedRolesId)
                builders.Add(Builders<Role>.Filter.Where(p => p.Id == roleId));

            var filter = Builders<Role>.Filter.Or(builders);
            return await _roles.Find(filter).ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Role>> GetListByPermissionIdAsync(string permissionId)
        {
            return await _roles.Find(r => r.PermissionsId.Contains(permissionId)).ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<long> CountByPermissionIdAsync(string permissionId)
        {
            return await _roles.CountDocumentsAsync(e => e.PermissionsId.Contains(permissionId));
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
