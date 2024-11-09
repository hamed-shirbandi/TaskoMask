using MongoDB.Bson;
using TaskoMask.Services.Owners.Read.Api.Domain;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.TestData;

internal static class OwnerObjectMother
{
    public static Owner GetOwnerWithEmail(string email)
    {
        return new Owner(ObjectId.GenerateNewId().ToString()) { DisplayName = email, Email = email };
    }
}
