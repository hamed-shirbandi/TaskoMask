using TaskoMask.Application.Core.Dtos.Cards;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.Cards.Queries.Models
{

    public class GetCardReportQuery : BaseQuery<CardReportDto>
    {
        public GetCardReportQuery(string cardId)
        {
            CardId = cardId;
        }

        public string CardId { get; }
    }
}
