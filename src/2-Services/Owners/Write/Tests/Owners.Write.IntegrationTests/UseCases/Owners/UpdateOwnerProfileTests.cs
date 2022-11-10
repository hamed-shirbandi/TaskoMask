using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Owners.UpdateOwnerProfile;
using TaskoMask.Services.Owners.Write.IntegrationTests.Fixtures;
using TaskoMask.Services.Owners.Write.IntegrationTests.TestData.ObjectMothers;
using Xunit;

namespace TaskoMask.Services.Owners.Write.IntegrationTests.UseCases.Owners
{
    public class UpdateOwnerProfileTests : IClassFixture<OwnerClassFixture>
    {

        #region Fields

        private readonly OwnerClassFixture _fixture;

        #endregion

        #region Ctor

        public UpdateOwnerProfileTests(OwnerClassFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Owner_Profile_Is_Updated_Properly()
        {
            //Arrange
            var expectedOwner = OwnerObjectMother.GetAnOwner(_fixture.OwnerValidatorService);
            await _fixture.SeedOwnerAsync(expectedOwner);

            var request = new UpdateOwnerProfileRequest(id: expectedOwner.Id, displayName: "TestNewName", email:"testNewMail@taskomask.ir");
            var updateOwnerProfileUseCase = new UpdateOwnerProfileUseCase(_fixture.OwnerAggregateRepository, _fixture.OwnerValidatorService, _fixture.MessageBus, _fixture.InMemoryBus);

            //Act
            var result = await updateOwnerProfileUseCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().Be(expectedOwner.Id);
            result.Message.Should().Be(ContractsMessages.Update_Success);
        }


        #endregion
    }
}
