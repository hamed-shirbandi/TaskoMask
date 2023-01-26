using TaskoMask.Services.Tasks.Read.Api.Domain;
using Xunit;

namespace TaskoMask.Services.Tasks.Read.Tests.Integration.Fixtures
{



    /// <summary>
    /// 
    /// </summary>
    [CollectionDefinition(nameof(ActivityCollectionFixture))]
    public class ActivityCollectionFixtureDefinition : ICollectionFixture<ActivityCollectionFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }



    /// <summary>
    /// 
    /// </summary>
    public class ActivityCollectionFixture : TestsBaseFixture
    {

        public ActivityCollectionFixture() : base(dbNameSuffix: nameof(ActivityCollectionFixture))
        {
        }




        /// <summary>
        /// 
        /// </summary>
        public async System.Threading.Tasks.Task SeedActivityAsync(Activity activity)
        {
            await DbContext.Activities.InsertOneAsync(activity);
        }

    }
}