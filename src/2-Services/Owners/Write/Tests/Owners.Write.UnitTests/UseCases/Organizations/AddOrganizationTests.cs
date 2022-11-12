using TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.AddOrganization;
using TaskoMask.Services.Owners.Write.UnitTests.Fixtures;

namespace TaskoMask.Services.Owners.Write.UnitTests.UseCases.Organizations
{
    public class AddOrganizationTests : TestsBaseFixture
    {

        #region Fields

        private AddOrganizationUseCase _addOrganizationUseCase;

        #endregion

        #region Ctor

        public AddOrganizationTests( )
        {
        }

        #endregion

        #region Test Methods





        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _addOrganizationUseCase = new AddOrganizationUseCase(OwnerAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
