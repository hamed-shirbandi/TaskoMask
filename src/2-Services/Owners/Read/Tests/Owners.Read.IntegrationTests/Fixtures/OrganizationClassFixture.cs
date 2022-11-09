using TaskoMask.Services.Owners.Read.Api.Domain;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.Fixtures
{

    /// <summary>
    /// 
    /// </summary>
    public class OrganizationClassFixture : TestsBaseFixture
    {

        public OrganizationClassFixture() : base(dbNameSuffix: nameof(OrganizationClassFixture))
        {
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task SeedOrganizationAsync(Organization organization)
        {
            await DbContext.Organizations.InsertOneAsync(organization);
        }

    }
}