using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Owners.Write.Api.UseCases.Owners.UpdateOwnerProfile;
using TaskoMask.Services.Owners.Write.Tests.Base.TestData;
using TaskoMask.Services.Owners.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Write.Tests.Integration.UseCases.Owners;

[Collection(nameof(OwnerCollectionFixture))]
public class UpdateOwnerProfileTests
{
    #region Fields

    private readonly OwnerCollectionFixture _fixture;

    #endregion

    #region Ctor

    public UpdateOwnerProfileTests(OwnerCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Owner_profile_is_updated()
    {
        //Arrange
        var expectedOwner = OwnerObjectMother.CreateOwner(_fixture._ownerValidatorService);
        await _fixture.SeedOwnerAsync(expectedOwner);

        var request = new UpdateOwnerProfileRequest(id: expectedOwner.Id, displayName: "Test New Name", email: "testNewMail@taskomask.ir");
        var updateOwnerProfileUseCase = new UpdateOwnerProfileUseCase(
            _fixture._ownerAggregateRepository,
            _fixture._ownerValidatorService,
            _fixture._eventPublisher,
            _fixture._requestDispatcher
        );

        //Act
        var result = await updateOwnerProfileUseCase.Handle(request, CancellationToken.None);

        //Assert
        result.EntityId.Should().Be(expectedOwner.Id);
        result.Message.Should().Be(ContractsMessages.Update_Success);

        var updatedOwner = await _fixture.GetOwnerAsync(expectedOwner.Id);
        updatedOwner.DisplayName.Value.Should().Be(request.DisplayName);
        updatedOwner.Email.Value.Should().Be(request.Email);
    }

    #endregion
}
