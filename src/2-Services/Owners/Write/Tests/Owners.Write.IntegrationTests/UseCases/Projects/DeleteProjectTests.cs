using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Projects.DeleteProject;
using TaskoMask.Services.Owners.Write.IntegrationTests.Fixtures;
using TaskoMask.Services.Owners.Write.IntegrationTests.TestData;
using Xunit;

namespace TaskoMask.Services.Owners.Write.IntegrationTests.UseCases.Projects
{
    public class DeleteProjectTests : IClassFixture<ProjectClassFixture>
    {

        #region Fields

        private readonly ProjectClassFixture _fixture;

        #endregion

        #region Ctor

        public DeleteProjectTests(ProjectClassFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Project_Is_Deleted_Properly()
        {
            //Arrange
            var expectedMessage = string.Format(ContractsMessages.Not_Found, DomainMetadata.Project);
            var expectedOwner = OwnerObjectMother.GetAnOwnerWithAnOrganizationAndProject(_fixture.OwnerValidatorService);
            var expectedOrganization = expectedOwner.Organizations.FirstOrDefault();
            var expectedProject = expectedOrganization.Projects.FirstOrDefault();
            await _fixture.SeedOwnerAsync(expectedOwner);

            var request = new DeleteProjectRequest(expectedProject.Id);
            var deleteProjectUseCase = new DeleteProjectUseCase(_fixture.OwnerAggregateRepository, _fixture.MessageBus, _fixture.InMemoryBus);

            //Act
            var result = await deleteProjectUseCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().Be(expectedProject.Id);
            result.Message.Should().Be(ContractsMessages.Update_Success);

            var updatedOwner = await _fixture.GetOwnerAsync(expectedOwner.Id);
            Action act = () => updatedOwner.GetProjectById(expectedProject.Id);
            act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));
        }


        #endregion
    }
}
