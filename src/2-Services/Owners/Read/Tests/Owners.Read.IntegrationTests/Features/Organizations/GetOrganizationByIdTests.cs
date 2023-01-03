using FluentAssertions;
using TaskoMask.Services.Owners.Read.Api.Features.Organizations.GetOrganizationById;
using TaskoMask.Services.Owners.Read.Tests.Integration.Fixtures;
using TaskoMask.Services.Owners.Read.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Services.Owners.Read.Tests.Integration.Features.Organizations
{
    [Collection(nameof(OrganizationCollectionFixture))]
    public class GetOrganizationByIdTests
    {

        #region Fields

        private readonly OrganizationCollectionFixture _fixture;

        #endregion

        #region Ctor

        public GetOrganizationByIdTests(OrganizationCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Organization_is_fetched_by_id()
        {
            //Arrange
            var expectedOrganization = OrganizationObjectMother.GetOrganization();
            await _fixture.SeedOrganizationAsync(expectedOrganization);
            var getOrganizationByIdHandler = new GetOrganizationByIdHandler(_fixture.DbContext, _fixture.Mapper);
            var request = new GetOrganizationByIdRequest(expectedOrganization.Id);

            //Act
            var result = await getOrganizationByIdHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Id.Should().Be(expectedOrganization.Id);
            result.Name.Should().Be(expectedOrganization.Name);
        }


        #endregion
    }
}
