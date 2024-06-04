using AutoMapper;
using Grpc.Core;
using MediatR;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Application.Queries;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Boards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Cards;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Protos;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Read.Api.Infrastructure.DbContext;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetBoardsByOrganizationIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetCardsByBoardIdGrpcService;
using static TaskoMask.BuildingBlocks.Contracts.Protos.GetTasksByCardIdGrpcService;


namespace TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationReportById;

public class GetOrganizationReportByIdHandler : BaseQueryHandler, IRequestHandler<GetOrganizationReportByIdRequest, OrganizationReportDto>
{
    #region Fields

    private readonly OwnerReadDbContext _ownerReadDbContext;
    private readonly GetBoardsByOrganizationIdGrpcServiceClient _getBoardsByOrganizationIdGrpcServiceClient;
    private readonly GetCardsByBoardIdGrpcServiceClient _getCardsByBoardIdGrpcServiceClient;
    private readonly GetTasksByCardIdGrpcServiceClient _getTasksByCardIdGrpcServiceClient;
    #endregion

    #region Ctors

    public GetOrganizationReportByIdHandler(OwnerReadDbContext ownerReadDbContext,
        GetBoardsByOrganizationIdGrpcServiceClient getBoardsByOrganizationIdGrpcServiceClient,
        GetCardsByBoardIdGrpcServiceClient getCardsByBoardIdGrpcServiceClient,
        GetTasksByCardIdGrpcServiceClient getTasksByCardIdGrpcServiceClient,
        IMapper mapper)
        : base(mapper)
    {
        _ownerReadDbContext = ownerReadDbContext;
        _getBoardsByOrganizationIdGrpcServiceClient = getBoardsByOrganizationIdGrpcServiceClient;
        _getCardsByBoardIdGrpcServiceClient = getCardsByBoardIdGrpcServiceClient;
        _getTasksByCardIdGrpcServiceClient = getTasksByCardIdGrpcServiceClient;
    }

    #endregion

    #region Handlers



    /// <summary>
    ///
    /// </summary>
    public async Task<OrganizationReportDto> Handle(GetOrganizationReportByIdRequest request, CancellationToken cancellationToken)
    {
        var organizationReportDto = new OrganizationReportDto();
        var organization = await _ownerReadDbContext.Organizations
            .Find(e => e.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (organization == null)
            throw new ApplicationException(ContractsMessages.Data_Not_exist, DomainMetadata.Organization);

        #region Project Reports
        var organizationProjects = await _ownerReadDbContext.Projects.Find(e => e.Id == organization.Id).ToListAsync(cancellationToken);
        organizationReportDto.ProjectsCount = organizationProjects?.Count ?? 0;
        #endregion

        #region Board Reports
        var boards = new List<GetBoardDto>();
        var boardsGrpcCall = _getBoardsByOrganizationIdGrpcServiceClient.Handle(
            new GetBoardsByOrganizationIdGrpcRequest { OrganizationId = organization.Id }
        );

        await foreach (var response in boardsGrpcCall.ResponseStream.ReadAllAsync())
            boards.Add(_mapper.Map<GetBoardDto>(response));

        organizationReportDto.BoardsCount = boards?.Count ?? 0;
        #endregion

        #region Task Reports
        long toDoTasksCount = 0;
        long doingTasksCount = 0;
        long doneTasksCount = 0;
        long backlogTasksCount = 0;

        var allBoardTasks = await GetAllTasksForBoardsAsync(boards, cancellationToken);

        foreach (var boardTask in allBoardTasks)
        {
            foreach (var cardTask in boardTask.CardTasks)
            {
                foreach (var task in cardTask.Tasks)
                {
                    switch (task.CardType)
                    {
                        case BoardCardType.ToDo:
                            toDoTasksCount++;
                            break;
                        case BoardCardType.Doing:
                            doingTasksCount++;
                            break;
                        case BoardCardType.Done:
                            doneTasksCount++;
                            break;
                        case BoardCardType.Backlog:
                            backlogTasksCount++;
                            break;
                    }
                }
            }
        }

        organizationReportDto.ToDoTasksCount = toDoTasksCount;
        organizationReportDto.DoingTasksCount = doingTasksCount;
        organizationReportDto.DoneTasksCount = doneTasksCount;
        organizationReportDto.BacklogTasksCount = backlogTasksCount;


        #endregion

        return organizationReportDto;
    }

    #endregion

    #region Private Methods
    private async Task<IEnumerable<BoardTasksViewModel>> GetAllTasksForBoardsAsync(IEnumerable<GetBoardDto> boards, CancellationToken cancellationToken)
    {
        var boardTasks = new List<BoardTasksViewModel>();

        foreach (var board in boards)
        {
            var cards = await GetCardsAsync(board.Id, cancellationToken);
            var cardTasks = new List<CardDetailsViewModel>();

            foreach (var card in cards)
            {
                var tasks = await GetTasksAsync(card.Card.Id);
                cardTasks.Add(new CardDetailsViewModel
                {
                    Card = card.Card,
                    Tasks = tasks
                });
            }

            boardTasks.Add(new BoardTasksViewModel
            {
                Board = board,
                CardTasks = cardTasks
            });
        }

        return boardTasks;
    }

    public class BoardTasksViewModel
    {
        public GetBoardDto Board { get; set; }
        public IEnumerable<CardDetailsViewModel> CardTasks { get; set; }
    }

    private async Task<IEnumerable<CardDetailsViewModel>> GetCardsAsync(string boardId, CancellationToken cancellationToken)
    {
        var cards = new List<CardDetailsViewModel>();

        var cardsGrpcCall = _getCardsByBoardIdGrpcServiceClient.Handle(new GetCardsByBoardIdGrpcRequest { BoardId = boardId });

        while (await cardsGrpcCall.ResponseStream.MoveNext(cancellationToken))
        {
            var currentCardGrpcResponse = cardsGrpcCall.ResponseStream.Current;

            cards.Add(
                new CardDetailsViewModel { Card = MapToCard(currentCardGrpcResponse), Tasks = await GetTasksAsync(currentCardGrpcResponse.Id), }
            );
        }

        return cards.AsEnumerable();
    }

    private async Task<IEnumerable<GetTaskDto>> GetTasksAsync(string cardId)
    {
        var tasks = new List<GetTaskDto>();

        var tasksGrpcCall = _getTasksByCardIdGrpcServiceClient.Handle(new GetTasksByCardIdGrpcRequest { CardId = cardId });

        await foreach (var response in tasksGrpcCall.ResponseStream.ReadAllAsync())
            tasks.Add(_mapper.Map<GetTaskDto>(response));

        return tasks;
    }

    private GetCardDto MapToCard(GetCardGrpcResponse cardGrpcResponse)
    {
        return _mapper.Map<GetCardDto>(cardGrpcResponse);
    }

    #endregion
}
