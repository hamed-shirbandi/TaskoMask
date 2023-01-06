using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Projects.AddProject;
using TaskoMask.Services.Owners.Write.Domain.Events.Projects;
using TaskoMask.Services.Owners.Write.Domain.ValueObjects.Projects;
using TaskoMask.Services.Owners.Write.Tests.Base.TestData;
using TaskoMask.Services.Owners.Write.Tests.Unit.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Write.Tests.Unit.UseCases.Projects
{
    public class AddProjectTests : TestsBaseFixture
    {

        #region Fields

        private AddProjectUseCase _addProjectUseCase;

        #endregion

        #region Ctor

        public AddProjectTests()
        {
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Project_is_added()
        {
            //Arrange
            var expectedOwner = Owners.FirstOrDefault();
            var expectedOrganization = OwnerObjectMother.CreateOrganization();
            expectedOwner.AddOrganization(expectedOrganization);

            var addProjectRequest = new AddProjectRequest(expectedOrganization.Id, "Test Name", "Test_Description");

            //Act
            var result = await _addProjectUseCase.Handle(addProjectRequest, CancellationToken.None);

            //Assert
            result.Message.Should().Be(ContractsMessages.Create_Success);
            result.EntityId.Should().NotBeNull();

            var addedProject = expectedOwner.GetProjectById(result.EntityId);
            addedProject.Should().NotBeNull();

            await InMemoryBus.Received(1).PublishEvent(Arg.Any<ProjectAddedEvent>());
            await MessageBus.Received(1).Publish(Arg.Any<ProjectAdded>());
        }



        [Fact]
        public async Task Add_project_throw_exception_if_organization_id_is_not_existed()
        {
            //Arrange
            var notExistedOrganizationId = ObjectId.GenerateNewId().ToString();
            var addProjectRequest = new AddProjectRequest(notExistedOrganizationId, "Test Name", "Test_Description");
            var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Owner);

            //Act
            System.Func<Task> act = async () => await _addProjectUseCase.Handle(addProjectRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
        }



        [InlineData("test", "test")]
        [InlineData("تست", "تست")]
        [Theory]
        public async Task Project_is_not_added_if_name_and_description_are_the_same(string name, string description)
        {
            //Arrange
            var expectedOwner = Owners.FirstOrDefault();
            var expectedOrganization = OwnerObjectMother.CreateOrganization();
            expectedOwner.AddOrganization(expectedOrganization);

            var addProjectRequest = new AddProjectRequest(expectedOrganization.Id, name, description);
            var expectedMessage = DomainMessages.Equal_Name_And_Description_Error;

            //Act
            System.Func<Task> act = async () => await _addProjectUseCase.Handle(addProjectRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
        }





        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _addProjectUseCase = new AddProjectUseCase(OwnerAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
