﻿using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Data;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Entities;
using TaskoMask.Infrastructure.Data.Core.Repositories;
using TaskoMask.Infrastructure.Data.Write.DbContext;

namespace TaskoMask.Infrastructure.Data.Write.Repositories.Workspace
{
    public class OwnerAggregateRepository : BaseAggregateRepository<Owner>, IOwnerAggregateRepository
    {
        #region Fields

        protected readonly IMongoCollection<Owner> _owners;


        #endregion

        #region Ctors

        public OwnerAggregateRepository(IWriteDbContext dbContext) : base(dbContext)
        {
            _owners = dbContext.GetCollection<Owner>();

        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<Owner> GetByOrganizationIdAsync(string organizationId)
        {
            return await _owners.Find(e => e.Organizations.Any(c => c.Id == organizationId)).FirstOrDefaultAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Owner> GetByProjectIdAsync(string projectId)
        {
            return await _owners.Find(e => e.Organizations.Any(c => c.Projects.Any(p=>p.Id == projectId))).FirstOrDefaultAsync();
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
