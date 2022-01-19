using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Workspace.Tasks.Data;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class TaskAggregateRepository : BaseAggregateRepository<Domain.Workspace.Tasks.Entities.Task>, ITaskAggregateRepository
    {
        #region Fields

        private readonly IMongoCollection<Domain.Workspace.Tasks.Entities.Task> _tasks;

        #endregion

        #region Ctors

        public TaskAggregateRepository(IMongoDbContext dbContext) : base(dbContext)
        {
            _tasks = dbContext.GetCollection<Domain.Workspace.Tasks.Entities.Task>();
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Domain.Workspace.Tasks.Entities.Task>> GetListByCardIdAsync(string cardId)
        {
            return await _tasks.AsQueryable().Where(o => o.CardId.Value == cardId).ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Domain.Workspace.Tasks.Entities.Task>> GetListByOrganizationIdAsync(string organizationId, int takeCount)
        {
           // return await _tasks.AsQueryable().Where(o => o.OrganizationId == organizationId).OrderByDescending(o=> o.CreationTime.CreateDateTime).Take(takeCount).ToListAsync();
            return await _tasks.AsQueryable().OrderByDescending(o=> o.CreationTime.CreateDateTime).Take(takeCount).ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> ExistByTitleAsync(string id, string title)
        {
            var task = await _tasks.Find(e => e.Title.Value == title).FirstOrDefaultAsync();
            return task != null && task.Id != id;
        }


        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Domain.Workspace.Tasks.Entities.Task> Search(int page, int recordsPerPage, string term, out int pageSize, out int totalItemCount)
        {
            var queryable = _tasks.AsQueryable();

            #region By term

            if (!string.IsNullOrEmpty(term))
            {
                queryable = queryable.Where(p => p.Title.Value.Contains(term) || p.Description.Value.Contains(term));
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
            return await _tasks.CountDocumentsAsync(b => b.CardId.Value == cardId);
        }



        #endregion

        #region Private Methods



        #endregion

    }
}
