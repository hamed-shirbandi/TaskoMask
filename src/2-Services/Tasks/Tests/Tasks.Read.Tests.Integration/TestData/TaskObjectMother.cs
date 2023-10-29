using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Test.TestData;
using TaskoMask.Services.Tasks.Read.Api.Domain;

namespace TaskoMask.Services.Tasks.Read.Tests.Integration.TestData;

internal static class TaskObjectMother
{
    public static Task CreateTask()
    {
        return new Task(ObjectId.GenerateNewId().ToString())
        {
            Title = TestDataGenerator.GetRandomName(10),
            Description = TestDataGenerator.GetRandomString(20),
            OwnerId = ObjectId.GenerateNewId().ToString(),
            OrganizationId = ObjectId.GenerateNewId().ToString(),
            ProjectId = ObjectId.GenerateNewId().ToString(),
            BoardId = ObjectId.GenerateNewId().ToString(),
            CardId = ObjectId.GenerateNewId().ToString(),
            CardName = TestDataGenerator.GetRandomName(10),
            CardType = BoardCardType.Backlog,
        };
    }
}
