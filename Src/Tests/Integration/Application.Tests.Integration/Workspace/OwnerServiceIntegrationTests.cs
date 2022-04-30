using FluentAssertions;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Tests.Integration.TestData;
using TaskoMask.Application.Tests.Integration.TestData.Fixtures;
using TaskoMask.Application.Workspace.Owners.Services;
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
        public async Task Owner_Is_Created()
        {
            //Arrange
            var dto = new OwnerRegisterDto
            {
                DisplayName= "Test DisplayName",
                Email="TestOwner@email.com",
                Password="TestPass"
            };

            //Act
            var result = await _fixture.OwnerService.CreateAsync(dto);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.EntityId.Should().NotBeNull();
        }





        #endregion

    }
}
