using TaskoMask.Services.Owners.Read.Api.Domain;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.Fixtures
{

    /// <summary>
    /// 
    /// </summary>
    public class OwnerClassFixture : TestsBaseFixture
    {

        public OwnerClassFixture() : base(dbNameSuffix: nameof(OwnerClassFixture))
        {
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task SeedOwnerAsync(Owner owner)
        {
            await DbContext.Owners.InsertOneAsync(owner);
        }

    }
}