using FluentAssertions;
using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Boards.Write.Application.UseCases.Boards.AddBoard;
using TaskoMask.Services.Boards.Write.Tests.Integration.Fixtures;
using Xunit;

namespace TaskoMask.Services.Boards.Write.Tests.Integration.UseCases.Boards
{
    [Collection(nameof(BoardCollectionFixture))]
    public class AddBoardTests
    {

        #region Fields

        private readonly BoardCollectionFixture _fixture;

        #endregion

        #region Ctor

        public AddBoardTests(BoardCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Board_is_added()
        {
            //Arrange
            var request = new AddBoardRequest(name: "Test Name", description: "Test Description", projectId: ObjectId.GenerateNewId().ToString());
            var addBoardUseCase = new AddBoardUseCase(_fixture.BoardAggregateRepository, _fixture.MessageBus, _fixture.InMemoryBus,_fixture.BoardValidatorService);

            //Act
            var result = await addBoardUseCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().NotBeNull();
            result.Message.Should().Be(ContractsMessages.Create_Success);

        }


        #endregion
    }
}
