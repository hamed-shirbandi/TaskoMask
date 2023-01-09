using MongoDB.Bson;
using NSubstitute;
using System.Linq;
using System.Threading;
using System;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Projects.DeleteProject;
using TaskoMask.Services.Owners.Write.Application.UseCases.Projects.DeleteProject;
using TaskoMask.Services.Owners.Write.Domain.Events.Projects;
using TaskoMask.Services.Owners.Write.Tests.Base.TestData;
using TaskoMask.Services.Owners.Write.Tests.Unit.Fixtures;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;

namespace TaskoMask.Services.Owners.Write.Tests.Unit.UseCases.Projects
{
    public class DeleteProjectTests : TestsBaseFixture
    {

        #region Fields

        private DeleteProjectUseCase _deleteProjectUseCase;

        #endregion

        #region Ctor

        public DeleteProjectTests()
        {
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Project_is_deleted()
        {
            //Arrange
            var expectedOwner = Owners.FirstOrDefault();
            var expectedOrganization = OwnerObjectMother.CreateOrganization();
            var expectedProject = OwnerObjectMother.CreateProject();
            expectedOwner.AddOrganization(expectedOrganization);
            expectedOwner.AddProject(expectedOrganization.Id, expectedProject);

            var deleteProjectRequest = new DeleteProjectRequest(expectedProject.Id);
            var expectedMessage = string.Format(ContractsMessages.Not_Found, DomainMetadata.Project);

            //Act
            var result = await _deleteProjectUseCase.Handle(deleteProjectRequest, CancellationToken.None);

            //Assert
            result.Message.Should().Be(ContractsMessages.Update_Success);
            result.EntityId.Should().Be(expectedProject.Id);

            //Act
            Action act = () => expectedOwner.GetProjectById(expectedProject.Id);

            //Assert
            act.Should().Throw<DomainException>().Where(e => e.Message.Equals(expectedMessage));

            await InMemoryBus.Received(1).PublishEvent(Arg.Any<ProjectDeletedEvent>());
            await MessageBus.Received(1).Publish(Arg.Any<ProjectDeleted>());
        }



        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _deleteProjectUseCase = new DeleteProjectUseCase(OwnerAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
