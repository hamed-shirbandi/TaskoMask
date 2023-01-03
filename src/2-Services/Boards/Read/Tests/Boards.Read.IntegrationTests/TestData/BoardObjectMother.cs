using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Test.TestData;
using TaskoMask.Services.Boards.Read.Api.Domain;

namespace TaskoMask.Services.Boards.Read.Tests.Integration.TestData
{
    internal static class BoardObjectMother
    {
        public static Board CreateBoard()
        {
            return new Board(ObjectId.GenerateNewId().ToString())
            {
                Name = TestDataGenerator.GetRandomName(10),
                Description = TestDataGenerator.GetRandomString(20),
                OwnerId = ObjectId.GenerateNewId().ToString(),
                OrganizationId = ObjectId.GenerateNewId().ToString(),
                ProjectId = ObjectId.GenerateNewId().ToString(),
                OrganizationName = TestDataGenerator.GetRandomName(10),
                ProjectName = TestDataGenerator.GetRandomName(10),
            };
        }

    }
}
