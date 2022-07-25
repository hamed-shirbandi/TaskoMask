using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Domain.ReadModel.Data;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Infrastructure.Data.Common.Repositories;
using TaskoMask.Infrastructure.Data.ReadModel.DbContext;

namespace TaskoMask.Infrastructure.Data.ReadModel.Repositories
{
    public class TaskRepository : BaseRepository<Domain.ReadModel.Entities.Task>, ITaskRepository
    {
        #region Fields

        private readonly IMongoCollection<Domain.ReadModel.Entities.Task> _tasks;

        #endregion

        #region Ctors

        public TaskRepository(IReadDbContext dbContext) : base(dbContext)
        {
            _tasks = dbContext.GetCollection<Domain.ReadModel.Entities.Task>();
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Domain.ReadModel.Entities.Task>> GetListByCardIdAsync(string cardId)
        {
            return await _tasks.AsQueryable()
                .Where(o => o.CardId == cardId && o.IsDeleted == false)
                .OrderByDescending(o => o.CreationTime.ModifiedDateTime)
                .ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Domain.ReadModel.Entities.Task>> GetListByOrganizationIdAsync(string organizationId, int takeCount, BoardCardType? cardType)
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
        public async Task<IEnumerable<Domain.ReadModel.Entities.Task>> GetPendingTasksByBoardsIdAsync(string[] boardsId, int takeCount)
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
        public IEnumerable<Domain.ReadModel.Entities.Task> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount)
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
            await _tasks.UpdateManyAsync(b => b.CardId == cardId, Builders<Domain.ReadModel.Entities.Task>.Update.Set(p => p.CardType, cardType));
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
