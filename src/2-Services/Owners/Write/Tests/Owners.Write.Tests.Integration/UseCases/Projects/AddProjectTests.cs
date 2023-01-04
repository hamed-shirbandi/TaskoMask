using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Projects.AddProject;
using TaskoMask.Services.Owners.Write.Tests.Base.TestData;
using TaskoMask.Services.Owners.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Write.Tests.Integration.UseCases.Projects
{
    [Collection(nameof(ProjectCollectionFixture))]
    public class AddProjectTests
    {

        #region Fields

        private readonly ProjectCollectionFixture _fixture;

        #endregion

        #region Ctor

        public AddProjectTests(ProjectCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Project_is_added()
        {
            //Arrange
            var expectedOwner = OwnerObjectMother.CreateOwnerWithOneOrganization(_fixture.OwnerValidatorService);
            var expectedOrganization = expectedOwner.Organizations.FirstOrDefault();
            await _fixture.SeedOwnerAsync(expectedOwner);

            var request = new AddProjectRequest(organizationId: expectedOrganization.Id, name: "Test Name", description: "Test Description");
            var addProjectUseCase = new AddProjectUseCase(_fixture.OwnerAggregateRepository, _fixture.MessageBus, _fixture.InMemoryBus);

            //Act
            var result = await addProjectUseCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().NotBeNull();
            result.Message.Should().Be(ContractsMessages.Create_Success);

            var updatedOwner = await _fixture.GetOwnerAsync(expectedOwner.Id);
            var addedProject = updatedOwner.GetProjectById(result.EntityId);
            addedProject.Name.Value.Should().Be(request.Name);
        }


        #endregion
    }
}
