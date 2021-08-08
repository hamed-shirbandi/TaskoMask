using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Application.Core.Dtos.Tasks;
using TaskoMask.Domain.Core.Queries;

namespace TaskoMask.Application.Tasks.Queries.Models
{
    public class GetTasksByCardIdQuery : BaseQuery<IEnumerable<TaskBasicInfoDto>>
    {
        public GetTasksByCardIdQuery(string cardId)
        {
            CardId = cardId;
        }

        public string CardId { get; }
    }
}
