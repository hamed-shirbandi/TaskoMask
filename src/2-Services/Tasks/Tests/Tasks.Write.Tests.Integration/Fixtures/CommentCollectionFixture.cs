
using Xunit;

namespace TaskoMask.Services.Tasks.Write.Tests.Integration.Fixtures
{


    /// <summary>
    /// 
    /// </summary>
    [CollectionDefinition(nameof(CommentCollectionFixture))]
    public class CommentCollectionFixtureDefinition : ICollectionFixture<CommentCollectionFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }



    /// <summary>
    /// 
    /// </summary>
    public class CommentCollectionFixture : TestsBaseFixture
    {
        public CommentCollectionFixture() : base(dbNameSuffix: nameof(CommentCollectionFixture))
        {
        }

    }
}