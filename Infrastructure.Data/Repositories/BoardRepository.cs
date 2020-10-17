using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Data;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Infrastructure.Data.Repositories
{
    public class BoardRepository : Repository<Domain.Models.Board>, IBoardRepository
    {
        public BoardRepository()
        {

        }
        public Task<IEnumerable<Board>> GetListByBoardIdAsync(string boardId)
        {
            throw new NotImplementedException();
        }
    }
}
