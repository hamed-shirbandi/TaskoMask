using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Test.TestData;
using TaskoMask.Services.Boards.Read.Api.Domain;

namespace TaskoMask.Services.Boards.Read.Tests.Integration.TestData;

internal static class CardObjectMother
{
    public static Card CreateCard()
    {
        return new Card(ObjectId.GenerateNewId().ToString())
        {
            Name = TestDataGenerator.GetRandomName(10),
            Type = BoardCardType.ToDo,
            BoardId = ObjectId.GenerateNewId().ToString(),
            ProjectId = ObjectId.GenerateNewId().ToString(),
            OrganizationId = ObjectId.GenerateNewId().ToString(),
            OwnerId = ObjectId.GenerateNewId().ToString(),
            BoardName = TestDataGenerator.GetRandomName(10),
        };
    }
}
