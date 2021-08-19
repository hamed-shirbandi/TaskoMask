using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        #region Fields

        private readonly IMongoCollection<Card> _cards;

        #endregion

        #region Ctors

        public CardRepository(IMainDbContext dbContext) : base(dbContext)
        {
            _cards = dbContext.GetCollection<Card>(); ;
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
            var organization = await _cards.Find(e => e.Name == name).FirstOrDefaultAsync();
            return organization != null && organization.Id != id;
        }

        #endregion

        #region Private Methods



        #endregion
     
    }
}
