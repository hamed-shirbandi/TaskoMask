using FluentAssertions;
using TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationById;
using TaskoMask.Services.Owners.Read.IntegrationTests.Fixtures;
using TaskoMask.Services.Owners.Read.IntegrationTests.TestData;
using Xunit;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.Features.Organizations
{
    public class GetOrganizationByIdTests : IClassFixture<OrganizationClassFixture>
    {

        #region Fields

        private readonly OrganizationClassFixture _fixture;

        #endregion

        #region Ctor

        public GetOrganizationByIdTests(OrganizationClassFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Organization_Is_Fetched()
        {
            //Arrange
            var expectedOrganization = OrganizationObjectMother.GetOrganization();
            await _fixture.SeedOrganizationAsync(expectedOrganization);
            var getOwnerByIdHandler = new GetOrganizationByIdHandler(_fixture.DbContext, _fixture.Mapper);
            var request = new GetOrganizationByIdRequest(expectedOrganization.Id);

            //Act
            var result = await getOwnerByIdHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Id.Should().Be(expectedOrganization.Id);
            result.Name.Should().Be(expectedOrganization.Name);
        }


        #endregion
    }
}
