using TaskoMask.Services.Owners.Write.Application.UseCases.Owners.UpdateOwnerProfile;
using TaskoMask.Services.Owners.Write.UnitTests.Fixtures;

namespace TaskoMask.Services.Owners.Write.UnitTests.UseCases.Owners
{
    public class UpdateOwnerProfileTests : TestsBaseFixture
    {

        #region Fields

        private UpdateOwnerProfileUseCase _updateOwnerProfileUseCase;

        #endregion

        #region Ctor

        public UpdateOwnerProfileTests()
        {
        }

        #endregion

        #region Test Methods





        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _updateOwnerProfileUseCase = new UpdateOwnerProfileUseCase(OwnerAggregateRepository,OwnerValidatorService, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
