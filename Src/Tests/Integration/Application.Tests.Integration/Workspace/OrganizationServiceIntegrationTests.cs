using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Dtos.Workspace.Organizations;
using TaskoMask.Application.Tests.Integration.Fixtures;
using Xunit;


namespace TaskoMask.Application.Tests.Integration.Workspace
{

    [Collection(nameof(OwnerCollectionFixture))]
    public class OrganizationServiceIntegrationTests
    {
        #region Fields

        private readonly OwnerCollectionFixture _fixture;

        #endregion

        #region Ctor

        public OrganizationServiceIntegrationTests(OwnerCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Organization_Is_Created()
        {
            //Arrange
            var owner = await _fixture.GetSampleOwnerAsync();
            var dto = new OrganizationUpsertDto
            {
                Name = "Test Organization Name",
                Description = "Test Organization Description",
                OwnerId = owner.Id,
            };

            //Act
            var result = await _fixture.OrganizationService.CreateAsync(dto);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.EntityId.Should().NotBeNull();

        }



        [Fact]
        public async Task Organization_List_By_OwnerId_Is_Fetched()
        {
            //Arrange
            var expectedOwner = await _fixture.GetSampleOwnerAsync();

            //Act
            var result = await _fixture.OrganizationService.GetListByOwnerIdAsync(expectedOwner.Id);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().HaveCountGreaterThan(0);
            var anyNotExpectedOwnerId = result.Value.Any(o => o.OwnerId != expectedOwner.Id);
            anyNotExpectedOwnerId.Should().BeFalse();
        }





        #endregion

    }
}
