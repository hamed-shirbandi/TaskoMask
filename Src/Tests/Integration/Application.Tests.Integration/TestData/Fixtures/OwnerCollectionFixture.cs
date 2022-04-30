
using Xunit;

namespace TaskoMask.Application.Tests.Integration.TestData.Fixtures
{

    /// <summary>
    /// 
    /// </summary>
    [CollectionDefinition("Owner Collection Fixture")]
    public class OwnerCollectionFixtureDefinition : ICollectionFixture<OwnerCollectionFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }


    public class OwnerCollectionFixture : TestsBaseFixture
    {
        public OwnerCollectionFixture( ) : base(dbNameSuffix: nameof(OwnerCollectionFixture))
        {
            SeedSampleData();
        }
    }
}
