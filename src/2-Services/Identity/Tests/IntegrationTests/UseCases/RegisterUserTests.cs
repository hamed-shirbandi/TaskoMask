using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Identity.Application.UseCases.RegisterUser;
using TaskoMask.Services.Identity.IntegrationTests.Fixtures;
using Xunit;

namespace TaskoMask.Services.Identity.IntegrationTests.UseCases
{
    [Collection(nameof(UserCollectionFixture))]
    public class RegisterUserTests
    {

        #region Fields

        private readonly UserCollectionFixture _fixture;

        #endregion

        #region Ctor

        public RegisterUserTests(UserCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task User_Is_Registered()
        {
            //Arrange
            var registerUserUseCase = new RegisterUserUseCase(_fixture.UserManager, _fixture.MessageBus, _fixture.InMemoryBus, _fixture.NotificationHandler);
            var request = new RegisterUserRequest("test@taskomask.ir", "TestPass");

            //Act
            var result = await registerUserUseCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().NotBeNullOrEmpty();
            result.Message.Should().Be(ContractsMessages.Create_Success);
        }


        #endregion
    }
}
