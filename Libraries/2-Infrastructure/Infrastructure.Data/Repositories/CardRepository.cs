using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;
using TaskoMask.Infrastructure.Data.DbContext;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        private readonly IMongoCollection<Card> _cards;
        public CardRepository(IMainDbContext dbContext) : base(dbContext)
        {
            _cards = dbContext.GetCollection<Card>(); ;
        }


        public async Task<IEnumerable<Card>> GetListByBoardIdAsync(string boardId)
        {
            return await _cards.AsQueryable().Where(o => o.BoardId == boardId).ToListAsync();

        }


        public async Task<bool> ExistByNameAsync(string id, string name)
        {
            var organization = await _cards.Find(e => e.Name == name).FirstOrDefaultAsync();
            return organization != null && organization.Id != id;
        }

    }
}
