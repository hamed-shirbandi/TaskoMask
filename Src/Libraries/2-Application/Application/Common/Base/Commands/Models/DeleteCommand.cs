using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Application.Common.Base.Commands.Models
{
    public class DeleteCommand<TEntity>:BaseCommand where TEntity :BaseEntity
    {
        public DeleteCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
