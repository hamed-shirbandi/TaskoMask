using System.Collections.Generic;
using System.Threading.Tasks;
using TaskoMask.Domain.Workspace.Boards.Entities;
using TaskoMask.Domain.Core.Data;

namespace TaskoMask.Domain.ReadModel.Data
{

    public interface ICardRepository : IBaseAggregateRepository<Card>
    {
    }
}
