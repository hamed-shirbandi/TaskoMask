using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Workspace.Data;
using TaskoMask.Domain.Workspace.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
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
            return await _cards.AsQueryable().Where(o => o.BoardId == boardId).ToListAsync();

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> ExistByNameAsync(string id, string name)
        {
            var card = await _cards.Find(e => e.Name == name).FirstOrDefaultAsync();
            return card != null && card.Id != id;
        }

        #endregion

        #region Private Methods



        #endregion
     
    }
}
