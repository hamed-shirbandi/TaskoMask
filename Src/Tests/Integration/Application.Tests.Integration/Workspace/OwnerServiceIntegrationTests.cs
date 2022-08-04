using FluentAssertions;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Tests.Integration.Fixtures;
using Xunit;


namespace TaskoMask.Application.Tests.Integration.Workspace
{

    [Collection(nameof(OwnerCollectionFixture))]
    public class OwnerServiceIntegrationTests 
    {
        #region Fields

        private readonly OwnerCollectionFixture _fixture;

        #endregion

        #region Ctor

        public OwnerServiceIntegrationTests(OwnerCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods



        [Fact]
        public async Task Owner_Is_Registered()
        {
            //Arrange
            var dto = new OwnerRegisterDto
            {
                DisplayName= "Test DisplayName",
                Email="TestOwner@email.com",
                Password="TestPass"
            };

            //Act
            var result = await _fixture.OwnerService.RegisterAsync(dto);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.EntityId.Should().NotBeNull();
        }



        [Fact]
        public async Task Owner_Details_Is_Fetched()
        {
            //Arrange
            var expectedOwner = await _fixture.GetSampleOwnerAsync();

            //Act
            var result = await _fixture.OwnerService.GetDetailsAsync(expectedOwner.Id);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Owner.UserInfo.UserName.Should().Be(expectedOwner.UserName);
            result.Value.Organizations.Should().HaveCountGreaterThan(0);
        }


        #endregion

    }
}
