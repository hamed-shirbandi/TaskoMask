using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Tests.Unit.TestData.DataBuilders;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Entities;
using TaskoMask.Domain.WriteModel.Workspace.Boards.Services;

namespace TaskoMask.Domain.Tests.Unit.TestData.ObjectMothers
{
    internal static class BoardObjectMother
    {


        public static Board CreateNewBoard(IBoardValidatorService boardValidatorService)
        {
            return BoardBuilder.Init(boardValidatorService)
                  .WithProjectId(ObjectId.GenerateNewId().ToString())
                  .WithName("Test Name")
                  .WithDescription("Test Description")
                  .Build();
        }



        public static Board CreateNewBoardWithId(string id, IBoardValidatorService boardValidatorService)
        {
            return BoardBuilder.Init(boardValidatorService)
                  .WithProjectId(id)
                  .WithName("Test Name")
                  .WithDescription("Test Description")
                  .Build();
        }



        public static Board CreateNewBoardWithName(string name, IBoardValidatorService boardValidatorService)
        {
            return BoardBuilder.Init(boardValidatorService)
                  .WithProjectId(ObjectId.GenerateNewId().ToString())
                  .WithName(name)
                  .WithDescription("Test Description")
                  .Build();
        }


   
        public static Board CreateNewBoardWithACard(IBoardValidatorService boardValidatorService)
        {
            var board = CreateNewBoard(boardValidatorService);
            var card = Card.Create("Test Card Name",BoardCardType.ToDo);
            board.CreateCard(card);
            return board;
        }
    }
}
