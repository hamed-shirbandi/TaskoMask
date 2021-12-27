using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.Common.Base.Commands.Models
{
    public class RecycleCommand<TEntity>:BaseCommand where TEntity :BaseEntity
    {
        public RecycleCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
