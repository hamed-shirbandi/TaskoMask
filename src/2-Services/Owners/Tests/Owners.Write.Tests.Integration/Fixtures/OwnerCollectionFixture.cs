using Xunit;

namespace TaskoMask.Services.Owners.Write.Tests.Integration.Fixtures;

/// <summary>
///
/// </summary>
[CollectionDefinition(nameof(OwnerCollectionFixture))]
public class OwnerCollectionFixtureDefinition : ICollectionFixture<OwnerCollectionFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}

/// <summary>
///
/// </summary>
public class OwnerCollectionFixture : TestsBaseFixture
{
    public OwnerCollectionFixture()
        : base(dbNameSuffix: nameof(OwnerCollectionFixture)) { }
}
