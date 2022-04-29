using FluentAssertions;
using System.Threading.Tasks;
using TaskoMask.Application.Tests.Integration.TestData;
using TaskoMask.Application.Workspace.Organizations.Services;
using Xunit;
using Xunit.Priority;

namespace TaskoMask.Application.Tests.Integration.Workspace
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [Collection("TestsBaseFixture collection")]
    public class OrganizationServiceIntegrationTests
    {
        #region Fields

        private readonly IOrganizationService _organizationService;
        private readonly TestsBaseFixture _fixture;

        #endregion

        #region Ctor

        public OrganizationServiceIntegrationTests(TestsBaseFixture fixture)
        {
            _fixture = fixture;
            _organizationService = _fixture.GetRequiredService<IOrganizationService>();
        }

        #endregion

        #region Test Mthods






        #endregion

    }
}
