using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Test.TestData;
using TaskoMask.Services.Boards.Write.Domain.Entities;
using TaskoMask.Services.Boards.Write.Domain.Services;

namespace TaskoMask.Services.Boards.Write.IntegrationTests.TestData
{
    internal static class BoardObjectMother
    {

        /// <summary>
        /// 
        /// </summary>

        public static Board CreateBoard(IBoardValidatorService boardValidatorService)
        {
            return Board.AddBoard(name: TestDataGenerator.GetRandomName(10), description: TestDataGenerator.GetRandomString(20), projectId: ObjectId.GenerateNewId().ToString(), boardValidatorService);
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
        public static Board CreateBoardWithCard(IBoardValidatorService boardValidatorService)
        {
            var board = CreateBoard(boardValidatorService);
            board.AddCard(CreateCard());
            return board;
        }

    }
}
