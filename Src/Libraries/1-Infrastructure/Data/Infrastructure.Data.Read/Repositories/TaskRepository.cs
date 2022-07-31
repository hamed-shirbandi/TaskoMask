using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Domain.DataModel.Data;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Infrastructure.Data.Core.Repositories;
using TaskoMask.Infrastructure.Data.Read.DbContext;

namespace TaskoMask.Infrastructure.Data.Read.Repositories
{
    public class TaskRepository : BaseRepository<Domain.DataModel.Entities.Task>, ITaskRepository
    {
        #region Fields

        private readonly IMongoCollection<Domain.DataModel.Entities.Task> _tasks;

        #endregion

        #region Ctors

        public TaskRepository(IReadDbContext dbContext) : base(dbContext)
        {
            _tasks = dbContext.GetCollection<Domain.DataModel.Entities.Task>();
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Domain.DataModel.Entities.Task>> GetListByCardIdAsync(string cardId)
        {
            return await _tasks.AsQueryable()
                .Where(o => o.CardId == cardId && o.IsDeleted == false)
                .OrderByDescending(o => o.CreationTime.ModifiedDateTime)
                .ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Domain.DataModel.Entities.Task>> GetListByOrganizationIdAsync(string organizationId, int takeCount, BoardCardType? cardType)
        {
            var queryable = _tasks.AsQueryable();

            if (cardType.HasValue)
                queryable = queryable.Where(p => p.CardType == cardType);

            return await queryable
                .Where(o => o.OrganizationId == organizationId && o.IsDeleted == false)
                .OrderByDescending(o => o.CreationTime.ModifiedDateTime)
                .Take(takeCount)
                .ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Domain.DataModel.Entities.Task>> GetPendingTasksByBoardsIdAsync(string[] boardsId, int takeCount)
        {
            var queryable = _tasks.AsQueryable();

            queryable = queryable.Where(p => p.CardType == BoardCardType.ToDo || p.CardType == BoardCardType.Doing);

            return await queryable
                .Where(o => boardsId.Contains(o.BoardId) && o.IsDeleted == false)
                .OrderByDescending(o => o.CreationTime.ModifiedDateTime)
                .Take(takeCount)
                .ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Domain.DataModel.Entities.Task> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount)
        {
            var queryable = _tasks.AsQueryable();

            #region By term

            if (!string.IsNullOrEmpty(term))
            {
                queryable = queryable.Where(p => p.Title.Contains(term) || p.Description.Contains(term));
            }

            #endregion

            #region SortOrder

            queryable = queryable.OrderByDescending(p => p.CreationTime.ModifiedDateTime);

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
        public async Task<long> CountByCardIdAsync(string cardId)
        {
            return await _tasks.CountDocumentsAsync(b => b.CardId == cardId && b.IsDeleted == false);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task BulkUpdateCardTypeByCardIdAsync(string cardId, BoardCardType cardType)
        {
            await _tasks.UpdateManyAsync(b => b.CardId == cardId, Builders<Domain.DataModel.Entities.Task>.Update.Set(p => p.CardType, cardType));
        }
        


        /// <summary>
        /// 
        /// </summary>
        public async Task<long> CountByCardsIdAsync(string[] cardsId, BoardCardType cardType)
        {
            return await _tasks.CountDocumentsAsync(b => cardsId.Contains(b.CardId) && b.CardType == cardType && b.IsDeleted == false);

        }




        #endregion

        #region Private Methods



        #endregion

    }
}
