using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Infrastructure.Data.Common.Repositories;
using TaskoMask.Infrastructure.Data.ReadModel.DbContext;

namespace TaskoMask.Infrastructure.Data.ReadModel.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        #region Fields

        private readonly IMongoCollection<Card> _cards;

        #endregion

        #region Ctors

        public CardRepository(IReadDbContext dbContext) : base(dbContext)
        {
            _cards = dbContext.GetCollection<Card>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Card>> GetListByBoardIdAsync(string boardId)
        {
            return await _cards.AsQueryable().Where(o => o.BoardId == boardId).ToListAsync();

        }



        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Card> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount)
        {
            var queryable = _cards.AsQueryable();

            #region By term

            if (!string.IsNullOrEmpty(term))
            {
                queryable = queryable.Where(p => p.Name.Contains(term) );
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



        /// <summary>
        /// 
        /// </summary>
        public async Task<long> CountByBoardIdAsync(string boardId)
        {
            return await _cards.CountDocumentsAsync(b => b.BoardId == boardId);
        }


        #endregion

        #region Private Methods



        #endregion

    }
}
