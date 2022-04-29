
using Xunit;

namespace TaskoMask.Application.Tests.Integration.TestData
{
    [CollectionDefinition("TestsBaseFixture collection")]
    public class TestsCollectionFixture : ICollectionFixture<TestsBaseFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
