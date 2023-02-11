using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;

namespace TaskoMask.Services.Boards.Read.Api.Features.Cards.GetCardById
{
    public class GetCardByIdRequest : BaseQuery<GetCardDto>
    {
        public GetCardByIdRequest(string id)
        {
            Id = id;
        }


        public string Id { get; }


    }
}
