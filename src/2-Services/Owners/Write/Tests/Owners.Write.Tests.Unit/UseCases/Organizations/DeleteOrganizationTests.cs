using TaskoMask.Services.Owners.Write.Application.UseCases.Organizations.DeleteOrganization;
using TaskoMask.Services.Owners.Write.Tests.Unit.Fixtures;

namespace TaskoMask.Services.Owners.Write.Tests.Unit.UseCases.Organizations
{
    public class DeleteOrganizationTests : TestsBaseFixture
    {

        #region Fields

        private DeleteOrganizationUseCase _deleteOrganizationUseCase;

        #endregion

        #region Ctor

        public DeleteOrganizationTests()
        {
        }

        #endregion

        #region Test Methods





        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _deleteOrganizationUseCase = new DeleteOrganizationUseCase(OwnerAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
