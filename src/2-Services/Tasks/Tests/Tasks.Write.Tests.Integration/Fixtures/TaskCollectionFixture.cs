
using Xunit;

namespace TaskoMask.Services.Tasks.Write.Tests.Integration.Fixtures
{


    /// <summary>
    /// 
    /// </summary>
    [CollectionDefinition(nameof(TaskCollectionFixture))]
    public class TaskCollectionFixtureDefinition : ICollectionFixture<TaskCollectionFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }



    /// <summary>
    /// 
    /// </summary>
    public class TaskCollectionFixture : TestsBaseFixture
    {
        public TaskCollectionFixture() : base(dbNameSuffix: nameof(TaskCollectionFixture))
        {
        }

    }
}