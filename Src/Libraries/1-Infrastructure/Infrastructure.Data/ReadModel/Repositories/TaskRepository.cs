using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.ReadModel.Data;
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
            return await _tasks.AsQueryable().Where(o => o.CardId == cardId).ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Domain.ReadModel.Entities.Task>> GetListByOrganizationIdAsync(string organizationId, int takeCount)
        {
            return await _tasks.AsQueryable().Where(o => o.OrganizationId == organizationId).OrderByDescending(o => o.CreationTime.CreateDateTime).Take(takeCount).ToListAsync();
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
        public async Task<long> CountByCardIdAsync(string cardId)
        {
            return await _tasks.CountDocumentsAsync(b => b.CardId == cardId);
        }




        #endregion

        #region Private Methods



        #endregion

    }
}
