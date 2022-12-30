using TaskoMask.Services.Boards.Write.Domain.Entities;
using TaskoMask.Services.Boards.Write.Domain.Services;

namespace TaskoMask.Services.Boards.Write.UnitTests.TestData
{
    internal class BoardBuilder
    {
        public IBoardValidatorService ValidatorService { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ProjectId { get; private set; }



        private BoardBuilder()
        {
        }



        public static BoardBuilder Init()
        {
            return new BoardBuilder();
        }



        public BoardBuilder WithValidatorService(IBoardValidatorService validatorService)
        {
            ValidatorService = validatorService;
            return this;
        }



        public BoardBuilder WithName(string name)
        {
            Name = name;
            return this;
        }



        public BoardBuilder WithDisplayName(string description)
        {
            Description = description;
            return this;
        }



        public BoardBuilder WithProjectIde(string projectId)
        {
            ProjectId = projectId;
            return this;
        }



        public Board AddBoard()
        {
            var board = Board.AddBoard(Name, Description, ProjectId, ValidatorService);
            board.ClearDomainEvents();
            return board;
        }


    }
}
