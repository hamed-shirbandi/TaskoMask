﻿using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.DataModel.Data;
using TaskoMask.Domain.DataModel.Entities;
using TaskoMask.Infrastructure.Data.Core.Repositories;
using TaskoMask.Infrastructure.Data.Read.DbContext;

namespace TaskoMask.Infrastructure.Data.Read.Repositories
{
    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        #region Fields

        private readonly IMongoCollection<Organization> _organizations;

        #endregion

        #region Ctors

        public OrganizationRepository(IReadDbContext dbContext) : base(dbContext)
        {
            _organizations = dbContext.GetCollection<Organization>();
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Organization>> GetListByOwnerIdAsync(string OwnerId)
        {
            return await _organizations.AsQueryable().Where(o => o.OwnerId == OwnerId).ToListAsync();
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
                queryable = queryable.Where(p => p.Name.Contains(term) || p.Description.Contains(term));
            }

            #endregion

            #region SortOrder

            queryable = queryable.OrderByDescending(p => p.CreationTime.CreateDateTime);

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



        /// <summary>
        /// 
        /// </summary>
        public async Task<long> CountByOwnerIdAsync(string OwnerId)
        {
            return await _organizations.CountDocumentsAsync(o => o.OwnerId == OwnerId );
        }




        #endregion

        #region Private Methods



        #endregion

    }
}
