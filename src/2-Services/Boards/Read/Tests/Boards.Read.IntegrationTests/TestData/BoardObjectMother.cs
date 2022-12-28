using MongoDB.Bson;
using TaskoMask.Services.Boards.Read.Api.Domain;

namespace TaskoMask.Services.Boards.Read.IntegrationTests.TestData
{
    internal static class BoardObjectMother
    {
        public static Board GetBoard()
        {
            return new Board(ObjectId.GenerateNewId().ToString())
            {
                Name = "Test Name",
                Description = "Test Description",
                OwnerId = ObjectId.GenerateNewId().ToString(),
                OrganizationId = ObjectId.GenerateNewId().ToString(),
                ProjectId = ObjectId.GenerateNewId().ToString(),
                OrganizationName = "Test Organization Name",
                ProjectName = "Test Project Name",
            };
        }

    }
}
