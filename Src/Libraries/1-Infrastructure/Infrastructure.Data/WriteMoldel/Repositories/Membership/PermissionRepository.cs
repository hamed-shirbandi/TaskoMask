using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Domain.WriteModel.Membership.Data;
using TaskoMask.Domain.WriteModel.Membership.Entities;
using TaskoMask.Infrastructure.Data.Common.Contracts;

namespace TaskoMask.Infrastructure.Data.WriteMoldel.Repositories.Membership
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        private readonly IMongoCollection<Permission> _permissions;
        public PermissionRepository(IMongoDbContext dbContext) : base(dbContext)
        {
            _permissions = dbContext.GetCollection<Permission>();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> ExistBySystemNameAsync(string id, string systemName)
        {
            var permission = await _permissions.Find(e => e.SystemName == systemName).FirstOrDefaultAsync();
            return permission != null && permission.Id != id;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Permission>> GetListByIdsAsync(string[] permissionsId)
        {
            if (permissionsId == null || permissionsId.Any() == false)
                return new List<Permission>();

            var builders = new List<FilterDefinition<Permission>>();
            foreach (var roleId in permissionsId)
                builders.Add(Builders<Permission>.Filter.Where(p => p.Id == roleId));

            var filter = Builders<Permission>.Filter.Or(builders);
            return await _permissions.Find(filter).ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Permission> Search(int page, int recordsPerPage, string term, string groupName, out int pageSize, out int totalItemCount)
        {
            var queryable = _permissions.AsQueryable();

            #region By term

            if (!string.IsNullOrEmpty(term))
            {
                queryable = queryable.Where(p => p.DisplayName.Contains(term) || p.SystemName.Contains(term) || p.GroupName.Contains(term));
            }

            #endregion

            #region By groupName

            if (!string.IsNullOrEmpty(groupName))
            {
                queryable = queryable.Where(p => p.GroupName == groupName);
            }

            #endregion

            #region SortOrder

            queryable = queryable.OrderByDescending(p => p.Id);

            #endregion

            #region  Skip Take

            totalItemCount = queryable.CountAsync().Result;
            pageSize = (int)Math.Ceiling((double)totalItemCount / recordsPerPage);

            page = page > pageSize || page < 1 ? 1 : page;


            var skiped = (page - 1) * recordsPerPage;
            queryable = queryable.Skip(skiped).Take(recordsPerPage);


            #endregion

            return queryable.ToList();
        }
    }
}
