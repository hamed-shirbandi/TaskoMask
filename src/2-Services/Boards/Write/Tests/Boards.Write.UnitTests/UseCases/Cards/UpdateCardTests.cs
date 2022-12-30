using TaskoMask.Services.Boards.Write.Application.UseCases.Cards.UpdateCard;
using TaskoMask.Services.Boards.Write.UnitTests.Fixtures;

namespace TaskoMask.Services.Boards.Write.UnitTests.UseCases.Cards
{
    public class UpdateCardTests : TestsBaseFixture
    {

        #region Fields

        private UpdateCardUseCase _updateCardUseCase;

        #endregion

        #region Ctor

        public UpdateCardTests()
        {
        }

        #endregion

        #region Test Methods





        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _updateCardUseCase = new UpdateCardUseCase(BoardAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
