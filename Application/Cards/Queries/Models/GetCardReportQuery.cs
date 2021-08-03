using MediatR;
using TaskoMask.Application.Core.Dtos.Cards;

namespace TaskoMask.Application.Cards.Queries.Models
{

    public class GetCardReportQuery : IRequest<CardReportDto>
    {
        public GetCardReportQuery(string cardId)
        {
            CardId = cardId;
        }

        public string CardId { get; }
    }
}
