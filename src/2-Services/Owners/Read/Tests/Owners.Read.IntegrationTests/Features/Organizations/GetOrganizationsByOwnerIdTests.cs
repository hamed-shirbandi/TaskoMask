using FluentAssertions;
using TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationsByOwnerId;
using TaskoMask.Services.Owners.Read.Tests.Integration.Fixtures;
using TaskoMask.Services.Owners.Read.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Services.Owners.Read.Tests.Integration.Features.Organizations
{
    [Collection(nameof(OrganizationCollectionFixture))]
    public class GetOrganizationsByOwnerIdTests
    {

        #region Fields

        private readonly OrganizationCollectionFixture _fixture;

        #endregion

        #region Ctor

        public GetOrganizationsByOwnerIdTests(OrganizationCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Organizations_are_fetched_by_owner_Id()
        {
            //Arrange
            var expectedOrganization = OrganizationObjectMother.GetOrganization();
            await _fixture.SeedOrganizationAsync(expectedOrganization);
            var getOrganizationsByOwnerIdHandler = new GetOrganizationsByOwnerIdHandler(_fixture.DbContext, _fixture.Mapper);
            var request = new GetOrganizationsByOwnerIdRequest(expectedOrganization.OwnerId);

            //Act
            var result = await getOrganizationsByOwnerIdHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Should().HaveCount(1);
            result.FirstOrDefault().Name.Should().Be(expectedOrganization.Name);
        }


        #endregion
    }
}
