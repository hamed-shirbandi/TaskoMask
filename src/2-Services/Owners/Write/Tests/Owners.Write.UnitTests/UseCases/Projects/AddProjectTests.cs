using TaskoMask.Services.Owners.Write.Application.UseCases.Projects.AddProject;
using TaskoMask.Services.Owners.Write.Tests.Unit.Fixtures;

namespace TaskoMask.Services.Owners.Write.Tests.Unit.UseCases.Projects
{
    public class AddProjectTests : TestsBaseFixture
    {

        #region Fields

        private AddProjectUseCase _addProjectUseCase;

        #endregion

        #region Ctor

        public AddProjectTests()
        {
        }

        #endregion

        #region Test Methods





        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _addProjectUseCase = new AddProjectUseCase(OwnerAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
