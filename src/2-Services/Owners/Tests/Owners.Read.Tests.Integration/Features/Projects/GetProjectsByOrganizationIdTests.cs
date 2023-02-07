using FluentAssertions;
using TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectsByOrganizationId;
using TaskoMask.Services.Owners.Read.Tests.Integration.Fixtures;
using TaskoMask.Services.Owners.Read.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Services.Owners.Read.Tests.Integration.Features.Project
{
    [Collection(nameof(ProjectCollectionFixture))]
    public class GetProjectsByOrganizationIdTests
    {

        #region Fields

        private readonly ProjectCollectionFixture _fixture;

        #endregion

        #region Ctor

        public GetProjectsByOrganizationIdTests(ProjectCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Projects_are_fetched_by_organization_Id()
        {
            //Arrange
            var expectedProject = ProjectObjectMother.GetProject();
            await _fixture.SeedProjectAsync(expectedProject);
            var getProjectsByOrganizationIdHandler = new GetProjectsByOrganizationIdHandler(_fixture.DbContext, _fixture.Mapper);
            var request = new GetProjectsByOrganizationIdRequest(expectedProject.OrganizationId);

            //Act
            var result = await getProjectsByOrganizationIdHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Should().HaveCount(1);
            result.FirstOrDefault().Name.Should().Be(expectedProject.Name);
        }


        #endregion
    }
}
