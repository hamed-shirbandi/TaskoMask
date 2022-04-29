using FluentAssertions;
using System.Threading.Tasks;
using TaskoMask.Application.Tests.Integration.TestData;
using TaskoMask.Application.Workspace.Projects.Services;
using Xunit;
using Xunit.Priority;

namespace TaskoMask.Application.Tests.Integration.Workspace
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [Collection("TestsBaseFixture collection")]
    public class ProjectServiceIntegrationTests
    {
        #region Fields

        private readonly IProjectService _projectService;
        private readonly TestsBaseFixture _fixture;

        #endregion

        #region Ctor

        public ProjectServiceIntegrationTests(TestsBaseFixture fixture)
        {
            _fixture = fixture;
            _projectService = _fixture.GetRequiredService<IProjectService>();
        }

        #endregion

        #region Test Mthods






        #endregion

    }
}
