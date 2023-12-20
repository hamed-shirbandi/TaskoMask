using TaskoMask.Services.Owners.Read.Api.Domain;
using Xunit;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.Fixtures;

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

    /// <summary>
    ///
    /// </summary>
    public async Task SeedOwnerAsync(Owner owner)
    {
        await _dbContext.Owners.InsertOneAsync(owner);
    }
}
