using System.Collections.Generic;
using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Test.TestData;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Entities;
using TaskoMask.Services.Boards.Write.Api.Domain.Boards.Services;

namespace TaskoMask.Services.Boards.Write.Tests.Base.TestData;

public static class BoardObjectMother
{
    /// <summary>
    ///
    /// </summary>

    public static Board CreateBoard(IBoardValidatorService boardValidatorService)
    {
        return BoardBuilder
            .Init()
            .WithValidatorService(boardValidatorService)
            .WithName(TestDataGenerator.GetRandomName(10))
            .WithDescription(TestDataGenerator.GetRandomName(20))
            .WithProjectId(ObjectId.GenerateNewId().ToString())
            .Build();
    }

    /// <summary>
    ///
    /// </summary>
    public static Card CreateCard()
    {
        return Card.Create(name: TestDataGenerator.GetRandomName(10), type: BoardCardType.ToDo);
    }

    /// <summary>
    ///
    /// </summary>
    public static Board CreateBoardWithOneCard(IBoardValidatorService boardValidatorService)
    {
        var board = CreateBoard(boardValidatorService);
        board.AddCard(CreateCard());
        board.ClearDomainEvents();
        return board;
    }

    /// <summary>
    ///
    /// </summary>
    public static List<Board> GenerateBoardsList(IBoardValidatorService boardValidatorService, int number = 3)
    {
        var list = new List<Board>();

        while (number-- > 0)
            list.Add(CreateBoard(boardValidatorService));

        return list;
    }
}
