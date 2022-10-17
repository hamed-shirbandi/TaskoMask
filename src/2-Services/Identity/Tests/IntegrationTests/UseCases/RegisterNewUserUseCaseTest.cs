using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Identity.Application.UseCases.RegisterNewUser;
using TaskoMask.Services.Identity.IntegrationTests.Fixtures;
using Xunit;

namespace TaskoMask.Services.Identity.IntegrationTests.UseCases
{
    public class RegisterNewUserUseCaseTest : IClassFixture<UserClassFixture>
    {

        #region Fields

        private readonly UserClassFixture _fixture;

        #endregion

        #region Ctor

        public RegisterNewUserUseCaseTest(UserClassFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task User_Is_Registered()
        {
            //Arrange
            var useCase = new RegisterNewUserUseCase(_fixture.UserManager, _fixture.InMemoryBus, _fixture.NotificationHandler);
            var request = new RegisterNewUserRequest("test@taskomask.ir", "TestPass");

            //Act
            var result = await useCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().NotBeNullOrEmpty();
            result.Message.Should().Be(ContractsMessages.Create_Success);
        }


        #endregion
    }
}
