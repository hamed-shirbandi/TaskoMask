

using TaskoMask.Services.Owners.Write.Domain.Entities;

namespace TaskoMask.Services.Owners.Write.IntegrationTests.Fixtures
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
            await OwnerAggregateRepository.CreateAsync(owner);
        }

    }
}