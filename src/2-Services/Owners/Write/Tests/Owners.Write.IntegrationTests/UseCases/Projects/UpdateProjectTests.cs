using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Projects.UpdateProject;
using TaskoMask.Services.Owners.Write.IntegrationTests.Fixtures;
using TaskoMask.Services.Owners.Write.IntegrationTests.TestData;
using Xunit;

namespace TaskoMask.Services.Owners.Write.IntegrationTests.UseCases.Projects
{
    public class UpdateProjectTests : IClassFixture<ProjectClassFixture>
    {

        #region Fields

        private readonly ProjectClassFixture _fixture;

        #endregion

        #region Ctor

        public UpdateProjectTests(ProjectClassFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Project_Is_Updated_Properly()
        {
            //Arrange
            var expectedOwner = OwnerObjectMother.GetAnOwnerWithAnOrganizationAndProject(_fixture.OwnerValidatorService);
            var expectedOrganization = expectedOwner.Organizations.FirstOrDefault();
            var expectedProject = expectedOrganization.Projects.FirstOrDefault();
            await _fixture.SeedOwnerAsync(expectedOwner);

            var request = new UpdateProjectRequest(id: expectedProject.Id, name: "Test New Name", description: "Test New Description");
            var updateProjectUseCase = new UpdateProjectUseCase(_fixture.OwnerAggregateRepository, _fixture.MessageBus, _fixture.InMemoryBus);

            //Act
            var result = await updateProjectUseCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().Be(expectedProject.Id);
            result.Message.Should().Be(ContractsMessages.Update_Success);

            var updatedOwner = await _fixture.GetOwnerAsync(expectedOwner.Id);
            var updatedProject = updatedOwner.GetProjectById(expectedProject.Id);
            updatedProject.Name.Should().Be(request.Name);
        }


        #endregion
    }
}
