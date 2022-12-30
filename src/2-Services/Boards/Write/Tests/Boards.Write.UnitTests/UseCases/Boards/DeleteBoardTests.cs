using TaskoMask.Services.Boards.Write.Application.UseCases.Boards.DeleteBoard;
using TaskoMask.Services.Boards.Write.UnitTests.Fixtures;

namespace TaskoMask.Services.Boards.Write.UnitTests.UseCases.Boards
{
    public class DeleteBoardTests : TestsBaseFixture
    {

        #region Fields

        private DeleteBoardUseCase _deleteBoardUseCase;

        #endregion

        #region Ctor

        public DeleteBoardTests()
        {
        }

        #endregion

        #region Test Methods





        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _deleteBoardUseCase = new DeleteBoardUseCase(BoardAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
