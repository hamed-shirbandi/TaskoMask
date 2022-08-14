using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.Services.Monolith.Infrastructure.Data.Core.Repositories;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DbContext;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Read.Repositories
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        #region Fields

        private readonly IMongoCollection<Member> _members;

        #endregion

        #region Ctors

        public MemberRepository(IReadDbContext dbContext) : base(dbContext)
        {
            _members = dbContext.GetCollection<Member>();
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Member>> GetListByBoardIdAsync(string boardId)
        {
            return await _members.AsQueryable().Where(o => o.BoardId == boardId ).ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Member>> GetListByOrganizationIdAsync(string organizationId)
        {
            return await _members.AsQueryable().Where(o => o.OrganizationId == organizationId ).ToListAsync();
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
