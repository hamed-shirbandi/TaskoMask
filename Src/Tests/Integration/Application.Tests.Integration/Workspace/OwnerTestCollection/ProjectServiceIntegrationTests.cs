using FluentAssertions;
using System.Threading.Tasks;
using TaskoMask.Application.Tests.Integration.TestData;
using TaskoMask.Application.Tests.Integration.TestData.Fixtures;
using TaskoMask.Application.Workspace.Projects.Services;
using Xunit;


namespace TaskoMask.Application.Tests.Integration.Workspace.OwnerTestCollection
{

    [Collection(nameof(OwnerCollectionFixture))]
    public class ProjectServiceIntegrationTests
    {
        #region Fields

        private readonly OwnerCollectionFixture _fixture;

        #endregion

        #region Ctor

        public ProjectServiceIntegrationTests(OwnerCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Mthods






        #endregion

    }
}
