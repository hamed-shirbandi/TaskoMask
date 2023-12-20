using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Test.TestData;
using TaskoMask.Services.Owners.Read.Api.Domain;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.TestData;

internal static class OrganizationObjectMother
{
    public static Organization GetOrganization()
    {
        return new Organization(ObjectId.GenerateNewId().ToString())
        {
            Name = TestDataGenerator.GetRandomName(10),
            Description = TestDataGenerator.GetRandomString(20),
            OwnerId = ObjectId.GenerateNewId().ToString(),
        };
    }
}
