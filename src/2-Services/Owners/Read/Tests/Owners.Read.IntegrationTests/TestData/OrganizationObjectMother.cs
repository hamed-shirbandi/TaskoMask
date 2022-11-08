using MongoDB.Bson;
using TaskoMask.Services.Owners.Read.Api.Domain;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.TestData
{
    internal static class OrganizationObjectMother
    {
        public static Organization GetOrganization()
        {
            return new Organization(ObjectId.GenerateNewId().ToString())
            {
                Name = "Test",
                Description = "Test",
                OwnerId= ObjectId.GenerateNewId().ToString()
            };
        }

    }
}
