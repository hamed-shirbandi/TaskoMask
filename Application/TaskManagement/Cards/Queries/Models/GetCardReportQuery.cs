using TaskoMask.Application.Core.Dtos.TaskManagement.Cards;
using TaskoMask.Application.Core.Queries;

namespace TaskoMask.Application.TaskManagement.Cards.Queries.Models
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
