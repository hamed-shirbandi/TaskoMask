using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Application.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Tasks.Queries.Models
{
    public class GetTasksByCardIdQuery : BaseQuery<IEnumerable<GetTaskDto>>
    {
        public GetTasksByCardIdQuery(string cardId)
        {
            CardId = cardId;
        }

        public string CardId { get; }
    }
}
