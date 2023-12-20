using TaskoMask.Services.Owners.Read.Api.Domain;
using Xunit;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.Fixtures;

/// <summary>
///
/// </summary>
[CollectionDefinition(nameof(OrganizationCollectionFixture))]
public class OrganizationCollectionFixtureDefinition : ICollectionFixture<OrganizationCollectionFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}

/// <summary>
///
/// </summary>
public class OrganizationCollectionFixture : TestsBaseFixture
{
    public OrganizationCollectionFixture()
        : base(dbNameSuffix: nameof(OrganizationCollectionFixture)) { }

    /// <summary>
    ///
    /// </summary>
    public async Task SeedOrganizationAsync(Organization organization)
    {
        await _dbContext.Organizations.InsertOneAsync(organization);
    }
}
