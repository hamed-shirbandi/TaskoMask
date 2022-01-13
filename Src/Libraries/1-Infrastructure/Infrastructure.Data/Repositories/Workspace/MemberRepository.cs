using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using TaskoMask.Domain.Workspace.Members.Data;
using TaskoMask.Domain.Workspace.Members.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories.Workspace
{
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        #region Fields

        protected readonly IMongoCollection<Member> _members;


        #endregion

        #region Ctors

        public MemberRepository(IMongoDbContext dbContext) : base(dbContext)
        {
            _members = dbContext.GetCollection<Member>();

        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Member> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount)
        {
            var queryable = _members.AsQueryable();

            #region By term

            if (!string.IsNullOrEmpty(term))
            {
                queryable = queryable.Where(p => p.DisplayName.Value.Contains(term) || p.Email.Value.Contains(term));
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
