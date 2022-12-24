using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Application.Queries;

namespace TaskoMask.Services.Monolith.Application.Workspace.Cards.Queries.Models
{
   
    public class GetCardByIdQuery : BaseQuery<GetCardDto>
    {
        public GetCardByIdQuery(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
