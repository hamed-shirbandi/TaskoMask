using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;

namespace TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTasksByCardId
{
    public class GetTasksByCardIdRequest : BaseQuery<IEnumerable<GetTaskDto>>
    {
        public GetTasksByCardIdRequest(string cardId)
        {
            CardId = cardId;
        }

        public string CardId { get; }
    }
}
