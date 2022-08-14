using TaskoMask.BuildingBlocks.Contracts.Dtos.Workspace.Cards;
using TaskoMask.Services.Monolith.Application.Core.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Cards.Queries.Models
{
   
    public class GetCardByIdQuery : BaseQuery<CardBasicInfoDto>
    {
        public GetCardByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
