using TaskoMask.Services.Owners.Write.Domain.Services;

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

    }
}