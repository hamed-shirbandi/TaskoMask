using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Boards.Services;

namespace TaskoMask.Services.Monolith.Domain.Tests.Unit.TestData.DataBuilders
{
    internal class BoardBuilder
    {
        private  IBoardValidatorService _boardValidatorService;
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ProjectId { get; private set; }


        private BoardBuilder(IBoardValidatorService boardValidatorService)
        {
            _boardValidatorService = boardValidatorService;
        }


        public static BoardBuilder Init(IBoardValidatorService boardValidatorService)
        {
            return new BoardBuilder(boardValidatorService);
        }


        public BoardBuilder WithName(string name)
        {
            Name = name;
            return this;
        }



        public BoardBuilder WithDescription(string description)
        {
            Description = description;
            return this;
        }


        public BoardBuilder WithProjectId(string projectId)
        {
            ProjectId = projectId;
            return this;
        }



        public Board AddBoard()
        {
            return Board.AddBoard(Name, Description, ProjectId ,_boardValidatorService);
        }


    }
}
