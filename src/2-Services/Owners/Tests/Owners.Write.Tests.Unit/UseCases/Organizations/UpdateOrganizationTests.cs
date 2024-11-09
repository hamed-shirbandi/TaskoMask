using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Events.Organizations;
using TaskoMask.Services.Owners.Write.Api.UseCases.Organizations.UpdateOrganization;
using TaskoMask.Services.Owners.Write.Tests.Base.TestData;
using TaskoMask.Services.Owners.Write.Tests.Unit.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Write.Tests.Unit.UseCases.Organizations;

public class UpdateOrganizationTests : TestsBaseFixture
{
    #region Fields

    private UpdateOrganizationUseCase updateOrganizationUseCase;

    #endregion

    #region Ctor

    public UpdateOrganizationTests() { }

    #endregion

    #region Test Methods



    [Fact]
    public async Task Organization_is_updated()
    {
        //Arrange
        var expectedOwner = Owners.FirstOrDefault();
        var expectedOrganization = OwnerObjectMother.CreateOrganization();
        expectedOwner.AddOrganization(expectedOrganization);
        var updateOrganizationRequest = new UpdateOrganizationRequest(expectedOrganization.Id, "Test New Name", "Test New Description");

        //Act
        var result = await updateOrganizationUseCase.Handle(updateOrganizationRequest, CancellationToken.None);

        //Assert
        result.Message.Should().Be(ContractsMessages.Update_Success);
        result.EntityId.Should().Be(expectedOrganization.Id);

        var updatedOrganization = expectedOwner.GetOrganizationById(expectedOrganization.Id);
        updatedOrganization.Name.Value.Should().Be(updateOrganizationRequest.Name);
        updatedOrganization.Description.Value.Should().Be(updateOrganizationRequest.Description);

        await InMemoryBus.Received(1).PublishEvent(Arg.Any<OrganizationUpdatedEvent>());
        await MessageBus.Received(1).Publish(Arg.Any<OrganizationUpdated>());
    }

    [Fact]
    public async Task Updating_an_organization_will_throw_an_exception_if_Id_is_not_existed()
    {
        //Arrange
        var notExistedOrganizationId = ObjectId.GenerateNewId().ToString();
        var updateOrganizationRequest = new UpdateOrganizationRequest(notExistedOrganizationId, "Test New Name", "Test New Description");
        var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Organization);

        //Act
        Func<Task> act = async () => await updateOrganizationUseCase.Handle(updateOrganizationRequest, CancellationToken.None);

        //Assert
        await act.Should().ThrowAsync<BuildingBlocks.Application.Exceptions.ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
    }

    #endregion

    #region Fixture

    protected override void TestClassFixtureSetup()
    {
        updateOrganizationUseCase = new UpdateOrganizationUseCase(OwnerAggregateRepository, MessageBus, InMemoryBus);
    }

    #endregion
}
