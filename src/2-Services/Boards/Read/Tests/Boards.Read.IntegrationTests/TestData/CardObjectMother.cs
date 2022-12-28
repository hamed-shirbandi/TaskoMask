using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.Services.Boards.Read.Api.Domain;

namespace TaskoMask.Services.Boards.Read.IntegrationTests.TestData
{
    internal static class CardObjectMother
    {
        public static Card GetCard()
        {
            return new Card(ObjectId.GenerateNewId().ToString())
            {
                Name = "Test Name",
                Type = BoardCardType.ToDo,
                BoardId = ObjectId.GenerateNewId().ToString(),
                ProjectId = ObjectId.GenerateNewId().ToString(),
                OrganizationId = ObjectId.GenerateNewId().ToString(),
                OwnerId = ObjectId.GenerateNewId().ToString(),
                BoardName = "Test Board Name",
            };
        }

    }
}
