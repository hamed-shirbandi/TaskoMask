using TaskoMask.Application.Core.Dtos.Workspace.Cards;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Workspace.Cards.Queries.Models
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
