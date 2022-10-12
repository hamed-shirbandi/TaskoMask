using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.DataModel.Data;
using TaskoMask.Services.Monolith.Domain.DataModel.Entities;
using TaskoMask.Services.Monolith.Infrastructure.Data.Read.DbContext;
using TaskoMask.BuildingBlocks.Infrastructure.MongoDB;

namespace TaskoMask.Services.Monolith.Infrastructure.Data.Read.Repositories
{
    public class CardRepository : MongoDbBaseRepository<Card>, ICardRepository
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
            return await _cards.AsQueryable()
                .Where(o => o.BoardId == boardId )
                .OrderBy(c=>c.Type)
                .OrderBy(c=>c.CreationTime.CreateDateTime)
                .ToListAsync();

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
                queryable = queryable.Where(p => p.Name.Contains(term));
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
        public async Task<long> CountByBoardIdAsync(string boardId)
        {
            return await _cards.CountDocumentsAsync(b => b.BoardId == boardId );
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<long> CountByOrganizationIdAsync(string organizationId)
        {
            return await _cards.CountDocumentsAsync(b => b.OrganizationId == organizationId );
        }



        /// <summary>
        /// 
        /// </summary>
        public string[] GetCardsIdByBoardsId(string[] boardsId)
        {
            return _cards
                .AsQueryable().Where(b => boardsId.Contains(b.BoardId) )
                .Select(b => b.Id)
                .ToArray();
        }


        #endregion

        #region Private Methods



        #endregion

    }
}
