using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.TaskManagement.Cards.Queries.Models
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
