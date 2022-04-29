
using Xunit;

namespace TaskoMask.Application.Tests.Integration.TestData
{

    /// <summary>
    /// If you want to share TestsBaseFixture for all test methods in some Test Classes
    /// You just need to apply [Collection("Owner Collection Fixture")] attribute for those classes
    /// And get TestsBaseFixture as a parameter in each test class constructor
    /// So the TestsBaseFixture initialize before all test methods in all test classes and then dispose after all tests run
    /// </summary>
    [CollectionDefinition("Owner Collection Fixture")]
    public class OwnerCollectionFixture : ICollectionFixture<TestsBaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
