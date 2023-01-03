using TaskoMask.Services.Boards.Read.Api.Domain;
using Xunit;

namespace TaskoMask.Services.Boards.Read.Tests.Integration.Fixtures
{


    /// <summary>
    /// 
    /// </summary>
    [CollectionDefinition(nameof(BoardCollectionFixture))]
    public class BoardCollectionFixtureDefinition : ICollectionFixture<BoardCollectionFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }



    /// <summary>
    /// 
    /// </summary>
    public class BoardCollectionFixture : TestsBaseFixture
    {

        public BoardCollectionFixture() : base(dbNameSuffix: nameof(BoardCollectionFixture))
        {
        }




        /// <summary>
        /// 
        /// </summary>
        public async Task SeedBoardAsync(Board board)
        {
            await DbContext.Boards.InsertOneAsync(board);
        }

    }
}