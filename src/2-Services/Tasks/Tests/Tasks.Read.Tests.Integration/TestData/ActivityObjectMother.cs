using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Test.TestData;
using TaskoMask.Services.Tasks.Read.Api.Domain;

namespace TaskoMask.Services.Tasks.Read.Tests.Integration.TestData
{
    internal static class ActivityObjectMother
    {
        public static Activity CreateActivity()
        {
            return new Activity()
            {
                Description = TestDataGenerator.GetRandomString(20),
                TaskId = ObjectId.GenerateNewId().ToString(),
            };
        }

    }
}
