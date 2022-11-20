using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Projects;
using TaskoMask.Services.Monolith.Application.Tests.Integration.Fixtures;
using Xunit;


namespace TaskoMask.Services.Monolith.Application.Tests.Integration.Workspace
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

        #region Test Methods




        #endregion

    }
}
