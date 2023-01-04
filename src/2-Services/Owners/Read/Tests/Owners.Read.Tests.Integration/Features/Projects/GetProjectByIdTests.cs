using FluentAssertions;
using TaskoMask.Services.Owners.Read.Api.Features.Projects.GetProjectById;
using TaskoMask.Services.Owners.Read.Tests.Integration.Fixtures;
using TaskoMask.Services.Owners.Read.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Services.Owners.Read.Tests.Integration.Features.Project
{
    [Collection(nameof(ProjectCollectionFixture))]
    public class GetProjectByIdTests
    {

        #region Fields

        private readonly ProjectCollectionFixture _fixture;

        #endregion

        #region Ctor

        public GetProjectByIdTests(ProjectCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Project_is_fetched_by_id()
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
