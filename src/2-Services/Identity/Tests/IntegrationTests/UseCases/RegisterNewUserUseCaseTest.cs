using FluentAssertions;
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
            var useCase = new RegisterNewUserUseCase(_fixture.UserManager);
            var request = new RegisterNewUserRequest
            {
                Email = "test@taskomask.ir",
                Password = "TestPass",
            };

            //Act
            var result = await useCase.Handle(request, CancellationToken.None);

            //Assert
            result.IsSuccess.Should().BeTrue();
        }


        #endregion
    }
}
