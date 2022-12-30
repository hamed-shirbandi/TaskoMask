using TaskoMask.Services.Boards.Write.Application.UseCases.Cards.AddCard;
using TaskoMask.Services.Boards.Write.UnitTests.Fixtures;

namespace TaskoMask.Services.Boards.Write.UnitTests.UseCases.Cards
{
    public class AddCardTests : TestsBaseFixture
    {

        #region Fields

        private AddCardUseCase _addCardUseCase;

        #endregion

        #region Ctor

        public AddCardTests()
        {
        }

        #endregion

        #region Test Methods





        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _addCardUseCase = new AddCardUseCase(BoardAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
