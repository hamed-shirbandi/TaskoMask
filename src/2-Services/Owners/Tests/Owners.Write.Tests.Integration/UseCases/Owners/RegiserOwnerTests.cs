using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Owners.Write.Api.UseCases.Owners.RegisterOwner;
using TaskoMask.Services.Owners.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Write.Tests.Integration.UseCases.Owners;

[Collection(nameof(OwnerCollectionFixture))]
public class RegiserOwnerTests
{
    #region Fields

    private readonly OwnerCollectionFixture _fixture;

    #endregion

    #region Ctor

    public RegiserOwnerTests(OwnerCollectionFixture fixture)
    {
        _fixture = fixture;
    }

    #endregion

    #region Test Methods


    [Fact]
    public async Task Owner_is_registered()
    {
        //Arrange
        var request = new RegiserOwnerRequest(displayName: "Test Name", email: "test@taskomask.ir", password: "TestPass");
        var regiserOwnerUseCase = new RegiserOwnerUseCase(
            _fixture._ownerAggregateRepository,
            _fixture._ownerValidatorService,
            _fixture._eventPublisher,
            _fixture._requestDispatcher
        );

        //Act
        var result = await regiserOwnerUseCase.Handle(request, CancellationToken.None);

        //Assert
        result.EntityId.Should().NotBeNull();
        result.Message.Should().Be(ContractsMessages.Create_Success);
    }

    #endregion
}
