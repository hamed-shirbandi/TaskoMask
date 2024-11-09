using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Application.Exceptions;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Events.Projects;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.ValueObjects.Projects;
using TaskoMask.Services.Owners.Write.Api.UseCases.Projects.AddProject;
using TaskoMask.Services.Owners.Write.Tests.Base.TestData;
using TaskoMask.Services.Owners.Write.Tests.Unit.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Write.Tests.Unit.UseCases.Projects;

public class AddProjectTests : TestsBaseFixture
{
    #region Fields

    private AddProjectUseCase addProjectUseCase;

    #endregion

    #region Ctor

    public AddProjectTests() { }

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
        var result = await addProjectUseCase.Handle(addProjectRequest, CancellationToken.None);

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
        var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Organization);

        //Act
        System.Func<Task> act = async () => await addProjectUseCase.Handle(addProjectRequest, CancellationToken.None);

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
        System.Func<Task> act = async () => await addProjectUseCase.Handle(addProjectRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
    }

    [InlineData("Th")]
    [InlineData("This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test")]
    [Theory]
    public async Task Project_is_not_added_if_name_lenght_is_less_than_min_or_more_than_max(string name)
    {
        //Arrange
        var expectedOwner = Owners.FirstOrDefault();
        var expectedOrganization = OwnerObjectMother.CreateOrganization();
        expectedOwner.AddOrganization(expectedOrganization);

        var addProjectRequest = new AddProjectRequest(expectedOrganization.Id, name, "Test Description");
        var expectedMessage = string.Format(
            ContractsMetadata.Length_Error,
            nameof(ProjectName),
            DomainConstValues.PROJECT_NAME_MIN_LENGTH,
            DomainConstValues.PROJECT_NAME_MAX_LENGTH
        );

        //Act
        System.Func<Task> act = async () => await addProjectUseCase.Handle(addProjectRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
    }

    [InlineData(
        "This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test This is a Test"
    )]
    [Theory]
    public async Task Project_is_not_added_if_description_lenght_is_more_than_max(string description)
    {
        //Arrange
        var expectedMessage = string.Format(
            ContractsMetadata.Max_Length_Error,
            nameof(ProjectDescription),
            DomainConstValues.PROJECT_DESCRIPTION_MAX_LENGTH
        );
        var expectedOwner = Owners.FirstOrDefault();
        var expectedOrganization = OwnerObjectMother.CreateOrganization();
        expectedOwner.AddOrganization(expectedOrganization);

        var addProjectRequest = new AddProjectRequest(expectedOrganization.Id, "Test Name", description);

        //Act
        System.Func<Task> act = async () => await addProjectUseCase.Handle(addProjectRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
    }

    [Fact]
    public async Task Project_is_not_added_if_name_is_not_unique()
    {
        //Arrange
        var expectedMessage = string.Format(DomainMessages.Name_Already_Exist, DomainMetadata.Project);
        var expectedOwner = Owners.FirstOrDefault();
        var expectedOrganization = OwnerObjectMother.CreateOrganization();
        var expectedProject = OwnerObjectMother.CreateProject();
        expectedOwner.AddOrganization(expectedOrganization);
        expectedOwner.AddProject(expectedOrganization.Id, expectedProject);

        var addProjectRequest = new AddProjectRequest(expectedOrganization.Id, expectedProject.Name.Value, "Test_Description");

        //Act
        System.Func<Task> act = async () => await addProjectUseCase.Handle(addProjectRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<DomainException>().Where(e => e.Message.Equals(expectedMessage));
    }

    #endregion

    #region Fixture

    protected override void TestClassFixtureSetup()
    {
        addProjectUseCase = new AddProjectUseCase(OwnerAggregateRepository, MessageBus, InMemoryBus);
    }

    #endregion
}
