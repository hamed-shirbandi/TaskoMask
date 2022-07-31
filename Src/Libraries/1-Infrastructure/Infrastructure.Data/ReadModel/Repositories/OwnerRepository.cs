using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.DataModel.Data;
using TaskoMask.Domain.DataModel.Entities;
using TaskoMask.Infrastructure.Data.Common.Repositories;
using TaskoMask.Infrastructure.Data.ReadModel.DbContext;

namespace TaskoMask.Infrastructure.Data.ReadModel.Repositories
{
    public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
    {
        #region Fields

        private readonly IMongoCollection<Owner> _owners;

        #endregion

        #region Ctors

        public OwnerRepository(IReadDbContext dbContext) : base(dbContext)
        {
            _owners = dbContext.GetCollection<Owner>();
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Owner> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount)
        {
            var queryable = _owners.AsQueryable();

            #region By term

            if (!string.IsNullOrEmpty(term))
            {
                queryable = queryable.Where(p => p.DisplayName.Contains(term) || p.Email.Contains(term));
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


        #endregion

        #region Private Methods



        #endregion

    }
}
