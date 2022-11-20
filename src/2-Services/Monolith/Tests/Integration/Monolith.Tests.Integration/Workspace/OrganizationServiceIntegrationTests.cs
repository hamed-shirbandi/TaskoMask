using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.Services.Monolith.Application.Tests.Integration.Fixtures;
using Xunit;


namespace TaskoMask.Services.Monolith.Application.Tests.Integration.Workspace
{

    [Collection(nameof(OwnerCollectionFixture))]
    public class OrganizationServiceIntegrationTests
    {
        #region Fields

        private readonly OwnerCollectionFixture _fixture;

        #endregion

        #region Ctor

        public OrganizationServiceIntegrationTests(OwnerCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods




        #endregion

    }
}
