using TaskoMask.Services.Owners.Write.Application.UseCases.Projects.DeleteProject;
using TaskoMask.Services.Owners.Write.Tests.Unit.Fixtures;

namespace TaskoMask.Services.Owners.Write.Tests.Unit.UseCases.Projects
{
    public class DeleteProjectTests : TestsBaseFixture
    {

        #region Fields

        private DeleteProjectUseCase _deleteProjectUseCase;

        #endregion

        #region Ctor

        public DeleteProjectTests()
        {
        }

        #endregion

        #region Test Methods





        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _deleteProjectUseCase = new DeleteProjectUseCase(OwnerAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
