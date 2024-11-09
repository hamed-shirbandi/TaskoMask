using AutoMapper;
using Grpc.Core;
using MediatR;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetBoardByIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetCardsByBoardIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetTasksByCardIdGrpcService;

namespace TaskoMask.ApiGateways.UserPanel.Aggregator.Features.GetBoardById;

public class GetBoardByIdHandler : BaseQueryHandler, IRequestHandler<GetBoardByIdRequest, BoardDetailsViewModel>
{
    #region Fields

    private readonly GetBoardByIdGrpcServiceClient _getBoardByIdGrpcServiceClient;
    private readonly GetCardsByBoardIdGrpcServiceClient _getCardsByBoardIdGrpcServiceClient;
    private readonly GetTasksByCardIdGrpcServiceClient _getTasksByCardIdGrpcServiceClient;

    #endregion

    #region Ctors

    public GetBoardByIdHandler(
        IMapper mapper,
        GetBoardByIdGrpcServiceClient getBoardByIdGrpcServiceClient,
        GetCardsByBoardIdGrpcServiceClient getCardsByBoardIdGrpcServiceClient,
        GetTasksByCardIdGrpcServiceClient getTasksByCardIdGrpcServiceClient
    )
        : base(mapper)
    {
        _getBoardByIdGrpcServiceClient = getBoardByIdGrpcServiceClient;
        _getCardsByBoardIdGrpcServiceClient = getCardsByBoardIdGrpcServiceClient;
        _getTasksByCardIdGrpcServiceClient = getTasksByCardIdGrpcServiceClient;
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
        var boardGrpcResponse = await _getBoardByIdGrpcServiceClient.HandleAsync(
            new GetBoardByIdGrpcRequest { Id = boardId },
            cancellationToken: cancellationToken
        );

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

            cards.Add(
                new CardDetailsViewModel { Card = MapToCard(currentCardGrpcResponse), Tasks = await GetTasksAsync(currentCardGrpcResponse.Id) }
            );
        }

        return cards.AsEnumerable();
    }

    /// <summary>
    ///
    /// </summary>
    private async Task<IEnumerable<GetTaskDto>> GetTasksAsync(string cardId)
    {
        var tasks = new List<GetTaskDto>();

        var tasksGrpcCall = _getTasksByCardIdGrpcServiceClient.Handle(new GetTasksByCardIdGrpcRequest { CardId = cardId });

        await foreach (var response in tasksGrpcCall.ResponseStream.ReadAllAsync())
            tasks.Add(_mapper.Map<GetTaskDto>(response));

        return tasks;
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
