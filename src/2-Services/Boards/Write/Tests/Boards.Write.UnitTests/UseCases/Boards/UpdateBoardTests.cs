using TaskoMask.Services.Boards.Write.Application.UseCases.Boards.UpdateBoard;
using TaskoMask.Services.Boards.Write.UnitTests.Fixtures;

namespace TaskoMask.Services.Boards.Write.UnitTests.UseCases.Boards
{
    public class UpdateBoardTests : TestsBaseFixture
    {

        #region Fields

        private UpdateBoardUseCase _updateBoardUseCase;

        #endregion

        #region Ctor

        public UpdateBoardTests()
        {
        }

        #endregion

        #region Test Methods





        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _updateBoardUseCase = new UpdateBoardUseCase(BoardAggregateRepository, MessageBus, InMemoryBus,BoardValidatorService);
        }

        #endregion
    }
}
