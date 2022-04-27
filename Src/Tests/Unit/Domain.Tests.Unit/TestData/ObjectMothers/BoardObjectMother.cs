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



        public static Board CreateNewBoard(string name, string description, IBoardValidatorService boardValidatorService)
        {
            return BoardBuilder.Init(boardValidatorService)
                  .WithProjectId(ObjectId.GenerateNewId().ToString())
                  .WithName(name)
                  .WithDescription(description)
                  .Build();
        }



        public static Board CreateNewBoardWithProjectId(string projectId, IBoardValidatorService boardValidatorService)
        {
            return BoardBuilder.Init(boardValidatorService)
                  .WithProjectId(projectId)
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

    }
}
