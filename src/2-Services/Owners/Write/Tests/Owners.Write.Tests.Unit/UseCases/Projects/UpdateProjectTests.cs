using MongoDB.Bson;
using NSubstitute;
using System.Linq;
using System.Threading;
using System;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Projects.UpdateProject;
using TaskoMask.Services.Owners.Write.Domain.Events.Projects;
using TaskoMask.Services.Owners.Write.Tests.Base.TestData;
using TaskoMask.Services.Owners.Write.Tests.Unit.Fixtures;
using Xunit;
using System.Threading.Tasks;
using FluentAssertions;

namespace TaskoMask.Services.Owners.Write.Tests.Unit.UseCases.Projects
{
    public class UpdateProjectTests : TestsBaseFixture
    {

        #region Fields

        private UpdateProjectUseCase _updateProjectUseCase;

        #endregion

        #region Ctor

        public UpdateProjectTests()
        {
        }

        #endregion

        #region Test Methods



        [Fact]
        public async Task Project_is_updated()
        {
            //Arrange
            var expectedOwner = Owners.FirstOrDefault();
            var expectedOrganization = OwnerObjectMother.CreateOrganization();
            var expectedProject = OwnerObjectMother.CreateProject();
            expectedOwner.AddOrganization(expectedOrganization);
            expectedOwner.AddProject(expectedOrganization.Id, expectedProject);

            var updateProjectRequest = new UpdateProjectRequest(expectedProject.Id, "Test New Name", "Test New Description");

            //Act
            var result = await _updateProjectUseCase.Handle(updateProjectRequest, CancellationToken.None);

            //Assert
            result.Message.Should().Be(ContractsMessages.Update_Success);
            result.EntityId.Should().Be(expectedProject.Id);

            var updatedProject = expectedOwner.GetProjectById(expectedProject.Id);
            updatedProject.Name.Value.Should().Be(updateProjectRequest.Name);
            updatedProject.Description.Value.Should().Be(updateProjectRequest.Description);

            await InMemoryBus.Received(1).PublishEvent(Arg.Any<ProjectUpdatedEvent>());
            await MessageBus.Received(1).Publish(Arg.Any<ProjectUpdated>());
        }



        [Fact]
        public async Task Updating_an_project_will_throw_an_exception_if_Id_is_not_existed()
        {
            //Arrange
            var notExistedProjectId = ObjectId.GenerateNewId().ToString();
            var updateProjectRequest = new UpdateProjectRequest(notExistedProjectId, "Test New Name", "Test New Description");
            var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Project);

            //Act
            Func<Task> act = async () => await _updateProjectUseCase.Handle(updateProjectRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<BuildingBlocks.Application.Exceptions.ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
        }



        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _updateProjectUseCase = new UpdateProjectUseCase(OwnerAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
