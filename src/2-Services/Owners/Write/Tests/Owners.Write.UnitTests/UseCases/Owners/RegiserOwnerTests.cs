using TaskoMask.Services.Owners.Write.Application.UseCases.Owners.RegiserOwner;
using TaskoMask.Services.Owners.Write.UnitTests.Fixtures;

namespace TaskoMask.Services.Owners.Write.UnitTests.UseCases.Owners
{
    public class RegiserOwnerTests : TestsBaseFixture
    {

        #region Fields

        private RegiserOwnerUseCase _regiserOwnerUseCase;

        #endregion

        #region Ctor

        public RegiserOwnerTests()
        {
        }

        #endregion

        #region Test Methods





        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _regiserOwnerUseCase = new RegiserOwnerUseCase(OwnerAggregateRepository, OwnerValidatorService, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
