using FluentAssertions;
using TaskoMask.Services.Owners.Read.Api.Features.Owners.GetOwnerById;
using TaskoMask.Services.Owners.Read.Tests.Integration.Fixtures;
using TaskoMask.Services.Owners.Read.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Services.Owners.Read.Tests.Integration.Features.Owners
{
    [Collection(nameof(OwnerCollectionFixture))]
    public class GetOwnerByIdTests
    {

        #region Fields

        private readonly OwnerCollectionFixture _fixture;

        #endregion

        #region Ctor

        public GetOwnerByIdTests(OwnerCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Owner_is_fetched_by_id()
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
