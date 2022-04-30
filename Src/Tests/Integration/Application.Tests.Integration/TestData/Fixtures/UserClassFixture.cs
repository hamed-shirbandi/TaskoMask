
using Xunit;

namespace TaskoMask.Application.Tests.Integration.TestData.Fixtures
{

    /// <summary>
    /// 
    /// </summary>
    public class UserClassFixture : TestsBaseFixture
    {
        public UserClassFixture( ) : base(dbNameSuffix: nameof(UserClassFixture))
        {
            SeedSampleData();
        }
    }
}
