using TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.UpdateOrganization;
using TaskoMask.Services.Owners.Write.Tests.Unit.Fixtures;

namespace TaskoMask.Services.Owners.Write.Tests.Unit.UseCases.Organizations
{
    public class UpdateOrganizationTests : TestsBaseFixture
    {

        #region Fields

        private UpdateOrganizationUseCase _updateOrganizationUseCase;

        #endregion

        #region Ctor

        public UpdateOrganizationTests()
        {
        }

        #endregion

        #region Test Methods





        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _updateOrganizationUseCase = new UpdateOrganizationUseCase(OwnerAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
