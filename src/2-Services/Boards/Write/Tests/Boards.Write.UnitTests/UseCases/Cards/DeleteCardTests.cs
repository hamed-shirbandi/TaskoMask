using TaskoMask.Services.Boards.Write.Application.UseCases.Cards.DeleteCard;
using TaskoMask.Services.Boards.Write.UnitTests.Fixtures;

namespace TaskoMask.Services.Boards.Write.UnitTests.UseCases.Cards
{
    public class DeleteCardTests : TestsBaseFixture
    {

        #region Fields

        private DeleteCardUseCase _deleteCardUseCase;

        #endregion

        #region Ctor

        public DeleteCardTests()
        {
        }

        #endregion

        #region Test Methods





        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _deleteCardUseCase = new DeleteCardUseCase(BoardAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
