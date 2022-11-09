using FluentAssertions;
using TaskoMask.Services.Owners.Read.Api.Features.Owners.GetOwnerById;
using TaskoMask.Services.Owners.Read.IntegrationTests.Fixtures;
using TaskoMask.Services.Owners.Read.IntegrationTests.TestData;
using Xunit;

namespace TaskoMask.Services.Owners.Read.IntegrationTests.Features.Owners
{
    public class GetOwnerByIdTests : IClassFixture<OwnerClassFixture>
    {

        #region Fields

        private readonly OwnerClassFixture _fixture;

        #endregion

        #region Ctor

        public GetOwnerByIdTests(OwnerClassFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Owner_Is_Fetched_By_Id()
        {
            //Arrange
            var expectedOwner = OwnerObjectMother.GetOwnerWithEmail("test@email.com");
            await _fixture.SeedOwnerAsync(expectedOwner);
            var getOwnerByIdHandler = new GetOwnerByIdHandler(_fixture.DbContext, _fixture.Mapper);
            var request = new GetOwnerByIdRequest(expectedOwner.Id);

            //Act
            var result = await getOwnerByIdHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Id.Should().Be(expectedOwner.Id);
            result.Email.Should().Be(expectedOwner.Email);
        }


        #endregion
    }
}
