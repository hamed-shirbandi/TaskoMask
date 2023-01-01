using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Write.Application.UseCases.Cards.DeleteCard;
using TaskoMask.Services.Boards.Write.Domain.Events.Cards;
using TaskoMask.Services.Boards.Write.UnitTests.Fixtures;
using TaskoMask.Services.Boards.Write.UnitTests.TestData;
using Xunit;

namespace TaskoMask.Services.Boards.Write.UnitTests.UseCases.Cards
{
    public class DeleteCardTests : TestsBaseFixture
    {

        #region Fields

        private DeleteCardUseCase _deleteCardUseCase;

        #endregion

        #region Ctor

        public DeleteCardTests()
        {
        }

        #endregion

        #region Test Methods



        [Fact]
        public async Task Card_Is_Deleted()
        {
            //Arrange
            var expectedBoard = Boards.FirstOrDefault();
            var expectedCard = BoardObjectMother.CreateCard();
            expectedBoard.AddCard(expectedCard);
            var deleteCardRequest = new DeleteCardRequest(expectedCard.Id);

            //Act
            var result = await _deleteCardUseCase.Handle(deleteCardRequest, CancellationToken.None);

            //Assert
            result.Message.Should().Be(ContractsMessages.Update_Success);
            result.EntityId.Should().Be(expectedCard.Id);

            var deletedCard = expectedBoard.GetCardById(expectedCard.Id);
            deletedCard.Should().BeNull();

            await InMemoryBus.Received(1).PublishEvent(Arg.Any<CardDeletedEvent>());
            await MessageBus.Received(1).Publish(Arg.Any<CardDeleted>());
        }



        [Fact]
        public async Task Deleting_A_Card_Will_Throw_An_Exception_When_Id_Is_Not_Existed()
        {
            //Arrange
            var notExistedCardId = ObjectId.GenerateNewId().ToString();
            var deleteCardRequest = new DeleteCardRequest(notExistedCardId);
            var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Card);

            //Act
            Func<Task> act = async () => await _deleteCardUseCase.Handle(deleteCardRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<BuildingBlocks.Application.Exceptions.ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
        }


        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _deleteCardUseCase = new DeleteCardUseCase(BoardAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
