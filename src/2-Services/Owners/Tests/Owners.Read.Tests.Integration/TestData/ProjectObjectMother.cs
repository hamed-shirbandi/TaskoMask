using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Test.TestData;
using TaskoMask.Services.Owners.Read.Api.Domain;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.TestData;

internal static class ProjectObjectMother
{
    public static Project GetProject()
    {
        return new Project(ObjectId.GenerateNewId().ToString())
        {
            Name = TestDataGenerator.GetRandomName(10),
            Description = TestDataGenerator.GetRandomString(20),
            OrganizationName = TestDataGenerator.GetRandomName(10),
            OrganizationId = ObjectId.GenerateNewId().ToString(),
            OwnerId = ObjectId.GenerateNewId().ToString(),
        };
    }
}
