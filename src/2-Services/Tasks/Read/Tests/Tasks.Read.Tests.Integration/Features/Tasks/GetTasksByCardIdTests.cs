using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Tasks.Read.Api.Features.Tasks.GetTasksByCardId;
using TaskoMask.Services.Tasks.Read.Tests.Integration.Fixtures;
using TaskoMask.Services.Tasks.Read.Tests.Integration.TestData;
using Xunit;

namespace TaskoMask.Services.Tasks.Read.Tests.Integration.Features.Tasks
{
    [Collection(nameof(TaskCollectionFixture))]
    public class GetTasksByCardIdTests
    {

        #region Fields

        private readonly TaskCollectionFixture _fixture;

        #endregion

        #region Ctor

        public GetTasksByCardIdTests(TaskCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Tasks_are_fetched_by_card_Id()
        {
            //Arrange
            var expectedTask = TaskObjectMother.CreateTask();
            await _fixture.SeedTaskAsync(expectedTask);
            var getTasksByCardIdHandler = new GetTasksByCardIdHandler(_fixture.DbContext, _fixture.Mapper);
            var request = new GetTasksByCardIdRequest(expectedTask.CardId);

            //Act
            var result = await getTasksByCardIdHandler.Handle(request, CancellationToken.None);

            //Assert
            result.Should().HaveCountGreaterThanOrEqualTo(1);
            result.Should().Contain(c => c.Id == expectedTask.Id);
        }


        #endregion
    }
}
