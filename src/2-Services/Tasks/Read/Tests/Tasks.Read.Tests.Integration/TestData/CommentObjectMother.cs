using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Test.TestData;
using TaskoMask.Services.Tasks.Read.Api.Domain;

namespace TaskoMask.Services.Tasks.Read.Tests.Integration.TestData
{
    internal static class CommentObjectMother
    {
        public static Comment CreateComment()
        {
            return new Comment(ObjectId.GenerateNewId().ToString())
            {
                Content = TestDataGenerator.GetRandomString(20),
                TaskId = ObjectId.GenerateNewId().ToString(),
            };
        }

    }
}
