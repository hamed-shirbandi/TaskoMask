using MongoDB.Bson;
using TaskoMask.Services.Owners.Read.Api.Domain;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.TestData
{
    internal static class ProjectObjectMother
    {
        public static Project GetProject()
        {
            return new Project(ObjectId.GenerateNewId().ToString())
            {
                Name = "Test",
                Description = "Test",
                OrganizationName = "Test",
                OrganizationId = ObjectId.GenerateNewId().ToString(),
                OwnerId = ObjectId.GenerateNewId().ToString(),
            };
        }

    }
}
