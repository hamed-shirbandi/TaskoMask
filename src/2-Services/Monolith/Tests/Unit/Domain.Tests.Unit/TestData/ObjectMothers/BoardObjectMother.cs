using MongoDB.Bson;
using TaskoMask.Services.Monolith.Domain.Tests.Unit.TestData.DataBuilders;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Services;

namespace TaskoMask.Services.Monolith.Domain.Tests.Unit.TestData.ObjectMothers
{
    internal static class BoardObjectMother
    {
        private const string _name = "Test Name";
        private const string _description = "Test Description";
        private static string _projectId = ObjectId.GenerateNewId().ToString();

        public static Board AddBoard(IBoardValidatorService boardValidatorService)
        {
            var board = BoardBuilder.Init(boardValidatorService)
                  .WithProjectId(_projectId)
                  .WithName(_name)
                  .WithDescription(_description)
                  .AddBoard();

            board.ClearDomainEvents();

            return board;
        }



        public static Board AddBoard(string name, string description, IBoardValidatorService boardValidatorService)
        {
            var board= BoardBuilder.Init(boardValidatorService)
                  .WithProjectId(_projectId)
                  .WithName(name)
                  .WithDescription(description)
                  .AddBoard();

            board.ClearDomainEvents();

            return board;
        }



        public static Board AddBoardWithProjectId(string projectId, IBoardValidatorService boardValidatorService)
        {
            var board = BoardBuilder.Init(boardValidatorService)
                  .WithProjectId(projectId)
                  .WithName(_name)
                  .WithDescription(_description)
                  .AddBoard();

            board.ClearDomainEvents();

            return board;
        }



        public static Board AddBoardWithName(string name, IBoardValidatorService boardValidatorService)
        {
            var board = BoardBuilder.Init(boardValidatorService)
                  .WithProjectId(_projectId)
                  .WithName(name)
                  .WithDescription(_description)
                  .AddBoard();

            board.ClearDomainEvents();

            return board;
        }

    }
}
