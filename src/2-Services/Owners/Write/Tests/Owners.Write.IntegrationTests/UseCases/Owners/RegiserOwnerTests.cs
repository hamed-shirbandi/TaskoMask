using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Owners.Write.Application.UseCases.Owners.RegiserOwner;
using TaskoMask.Services.Owners.Write.IntegrationTests.Fixtures;
using Xunit;

namespace TaskoMask.Services.Owners.Write.IntegrationTests.UseCases.Owners
{
    public class RegiserOwnerTests : IClassFixture<OwnerClassFixture>
    {

        #region Fields

        private readonly OwnerClassFixture _fixture;

        #endregion

        #region Ctor

        public RegiserOwnerTests(OwnerClassFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Owner_Is_Registered_Properly()
        {
            //Arrange
            var request = new RegiserOwnerRequest(displayName:"Test",email:"test@taskomask.ir",password:"TestPass");
            var regiserOwnerUseCase = new RegiserOwnerUseCase(_fixture.OwnerAggregateRepository, _fixture.OwnerValidatorService, _fixture.MessageBus, _fixture.InMemoryBus);

            //Act
            var result = await regiserOwnerUseCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().NotBeNull();
            result.Message.Should().Be(ContractsMessages.Create_Success);
        }


        #endregion
    }
}
