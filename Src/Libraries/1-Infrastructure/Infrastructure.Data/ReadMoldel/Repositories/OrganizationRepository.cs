using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Data;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;
using TaskoMask.Infrastructure.Data.WriteMoldel.DbContext;
using TaskoMask.Infrastructure.Data.WriteMoldel.Repositories;

namespace TaskoMask.Infrastructure.Data.ReadMoldel.Repositories
{
    public class OrganizationRepository : BaseAggregateRepository<Organization>, IOrganizationRepository
    {
        #region Fields

        private readonly IMongoCollection<Organization> _organizations;

        #endregion

        #region Ctors

        public OrganizationRepository(IMongoDbContext dbContext) : base(dbContext)
        {
            _organizations = dbContext.GetCollection<Organization>();
        }



        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> ExistByNameAsync(string id, string ownerOwnerId, string name)
        {
            var organization = await _organizations.Find(o => o.Name.Value == name && o.OwnerOwnerId.Value == ownerOwnerId).FirstOrDefaultAsync();
            return organization != null && organization.Id != id;
        }



        /// <summary>
        /// 
        /// </summary>
        public bool ExistByName(string id, string ownerOwnerId, string name)
        {
            var organization =  _organizations.Find(o => o.Name.Value == name && o.OwnerOwnerId.Value==ownerOwnerId).FirstOrDefault();
            return organization != null && organization.Id != id;
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Organization>> GetListByOwnerOwnerIdAsync(string ownerOwnerId)
        {
            return await _organizations.AsQueryable().Where(o => o.OwnerOwnerId.Value == ownerOwnerId).ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<long> CountByOwnerOwnerIdAsync(string ownerOwnerId)
        {
            return await _organizations.CountDocumentsAsync(o => o.OwnerOwnerId.Value == ownerOwnerId);
        }



        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Organization> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount)
        {
            var queryable = _organizations.AsQueryable();

            #region By term

            if (!string.IsNullOrEmpty(term))
            {
                queryable = queryable.Where(p => p.Name.Value.Contains(term) || p.Description.Value.Contains(term));
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


        #endregion

        #region Private Methods



        #endregion

    }
}
