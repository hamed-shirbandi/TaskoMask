using AutoMapper;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetBoardByIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetCardsByBoardIdGrpcService;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetBoardById
{
    public class GetBoardByIdHandler : BaseQueryHandler, IRequestHandler<GetBoardByIdRequest, BoardDetailsViewModel>
    {
        #region Fields

        private readonly GetBoardByIdGrpcServiceClient _getBoardByIdGrpcServiceClient;
        private readonly GetCardsByBoardIdGrpcServiceClient _getCardsByBoardIdGrpcServiceClient;

        #endregion

        #region Ctors

        public GetBoardByIdHandler(IMapper mapper, GetBoardByIdGrpcServiceClient getBoardByIdGrpcServiceClient, GetCardsByBoardIdGrpcServiceClient getCardsByBoardIdGrpcServiceClient) : base(mapper)
        {
            _getBoardByIdGrpcServiceClient = getBoardByIdGrpcServiceClient;
            _getCardsByBoardIdGrpcServiceClient = getCardsByBoardIdGrpcServiceClient;
        }

        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<BoardDetailsViewModel> Handle(GetBoardByIdRequest request, CancellationToken cancellationToken)
        {
            return new BoardDetailsViewModel
            {
                Board = await GetBoardAsync(request.Id, cancellationToken),
                Cards = await GetCardsAsync(request.Id, cancellationToken),
            };
        }


        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private async Task<GetBoardDto> GetBoardAsync(string boardId, CancellationToken cancellationToken)
        {
            var boardGrpcResponse = await _getBoardByIdGrpcServiceClient.HandleAsync(new GetBoardByIdGrpcRequest { Id = boardId },cancellationToken: cancellationToken);

            return _mapper.Map<GetBoardDto>(boardGrpcResponse);
        }



        /// <summary>
        /// 
        /// </summary>
        private async Task<IEnumerable<CardDetailsViewModel>> GetCardsAsync(string boardId, CancellationToken cancellationToken)
        {
            var cards = new List<CardDetailsViewModel>();

            var cardsGrpcCall = _getCardsByBoardIdGrpcServiceClient.Handle(new GetCardsByBoardIdGrpcRequest { BoardId = boardId });

            while (await cardsGrpcCall.ResponseStream.MoveNext(cancellationToken))
            {
                var currentCardGrpcResponse = cardsGrpcCall.ResponseStream.Current;

                cards.Add(new CardDetailsViewModel
                {
                    Card = MapToCard(currentCardGrpcResponse),
                    //TODO get tasks from task service
                    Tasks = new List<GetTaskDto>(),
                });
            }

            return cards.AsEnumerable();
        }



        /// <summary>
        /// 
        /// </summary>
        private GetCardDto MapToCard(GetCardGrpcResponse cardGrpcResponse)
        {
            return _mapper.Map<GetCardDto>(cardGrpcResponse);
        }



        #endregion

    }
}
