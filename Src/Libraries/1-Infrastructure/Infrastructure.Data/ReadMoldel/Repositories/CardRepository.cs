using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;
using TaskoMask.Infrastructure.Data.WriteMoldel.DbContext;
using TaskoMask.Infrastructure.Data.WriteMoldel.Repositories;

namespace TaskoMask.Infrastructure.Data.ReadMoldel.Repositories
{
    public class CardRepository : BaseAggregateRepository<Card>, ICardRepository
    {
        #region Fields

        private readonly IMongoCollection<Card> _cards;

        #endregion

        #region Ctors

        public CardRepository(IMongoDbContext dbContext) : base(dbContext)
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
           // return await _cards.AsQueryable().Where(o => o.BoardId == boardId).ToListAsync();
            return await _cards.AsQueryable().ToListAsync();

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> ExistByNameAsync(string id, string name)
        {
            var card = await _cards.Find(e => e.Name.Value == name).FirstOrDefaultAsync();
            return card != null && card.Id != id;
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
                queryable = queryable.Where(p => p.Name.Value.Contains(term));
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
           // return await _cards.CountDocumentsAsync(b => b.BoardId == boardId);
            return await _cards.CountDocumentsAsync(c=>true);
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
