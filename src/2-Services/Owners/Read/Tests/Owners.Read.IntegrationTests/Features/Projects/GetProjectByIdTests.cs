using FluentAssertions;
using TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectById;
using TaskoMask.Services.Owners.Read.IntegrationTests.Fixtures;
using TaskoMask.Services.Owners.Read.IntegrationTests.TestData;
using Xunit;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.Features.Project
{
    public class GetProjectByIdTests : IClassFixture<ProjectClassFixture>
    {

        #region Fields

        private readonly ProjectClassFixture _fixture;

        #endregion

        #region Ctor

        public GetProjectByIdTests(ProjectClassFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Project_Is_Fetched_By_Id()
        {
            //Arrange
            var expectedProject = ProjectObjectMother.GetProject();
            await _fixture.SeedProjectAsync(expectedProject);
            var getProjectByIdHandler = new GetProjectByIdHandler(_fixture.DbContext, _fixture.Mapper);
            var request = new GetProjectByIdRequest(expectedProject.Id);

            //Act
            var result = await getProjectByIdHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Id.Should().Be(expectedProject.Id);
            result.Name.Should().Be(expectedProject.Name);
        }


        #endregion
    }
}
