using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Test.TestData;
using TaskoMask.Services.Boards.Write.Domain.Entities;
using TaskoMask.Services.Boards.Write.Domain.Services;

namespace TaskoMask.Services.Boards.Write.UnitTests.TestData
{
    internal static class BoardObjectMother
    {

        /// <summary>
        /// 
        /// </summary>

        public static Board GetABoard(IBoardValidatorService boardValidatorService)
        {
            var board= Board.AddBoard(name: TestDataGenerator.GetRandomName(10), description: TestDataGenerator.GetRandomString(20), projectId: ObjectId.GenerateNewId().ToString(), boardValidatorService);
            board.ClearDomainEvents();
            return board;
        }



        /// <summary>
        /// 
        /// </summary>

        public static Card GetACard()
        {
            return Card.Create(name: TestDataGenerator.GetRandomName(10), type: BoardCardType.ToDo);
        }



        /// <summary>
        /// 
        /// </summary>
        public static List<Board> GenerateBoardsList(IBoardValidatorService boardValidatorService,int number = 3)
        {
            var list = new List<Board>();
            var projectId = ObjectId.GenerateNewId().ToString();
            for (int i = 1; i <= number; i++)
            {
                var board = Board.AddBoard($"Test Name {i}", $"Test Description {i}", projectId, boardValidatorService);
                board.ClearDomainEvents();
                list.Add(board);
            }

            return list;
        }
    }
}
