using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Events;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Boards.Write.Application.UseCases.Cards.UpdateCard;
using TaskoMask.Services.Boards.Write.Domain.Events.Cards;
using TaskoMask.Services.Boards.Write.Tests.Unit.Fixtures;
using TaskoMask.Services.Boards.Write.Tests.Base.TestData;
using Xunit;

namespace TaskoMask.Services.Boards.Write.Tests.Unit.UseCases.Cards
{
    public class UpdateCardTests : TestsBaseFixture
    {

        #region Fields

        private UpdateCardUseCase _updateCardUseCase;

        #endregion

        #region Ctor

        public UpdateCardTests()
        {
        }

        #endregion

        #region Test Methods



        [Fact]
        public async Task Card_is_updated()
        {
            //Arrange
            var expectedBoard = Boards.FirstOrDefault();
            var expectedCard = BoardObjectMother.CreateCard();
            expectedBoard.AddCard(expectedCard);
            var updateCardRequest = new UpdateCardRequest(expectedCard.Id,"Test New Name",BoardCardType.Done);

            //Act
            var result = await _updateCardUseCase.Handle(updateCardRequest, CancellationToken.None);

            //Assert
            result.Message.Should().Be(ContractsMessages.Update_Success);
            result.EntityId.Should().Be(expectedCard.Id);

            var updatedCard = expectedBoard.GetCardById(expectedCard.Id);
            updatedCard.Name.Value.Should().Be(updateCardRequest.Name);
            updatedCard.Type.Value.Should().Be(updateCardRequest.Type);

            await InMemoryBus.Received(1).PublishEvent(Arg.Any<CardUpdatedEvent>());
            await MessageBus.Received(1).Publish(Arg.Any<CardUpdated>());
        }



        [Fact]
        public async Task Updating_a_card_will_throw_an_exception_if_Id_is_not_existed()
        {
            //Arrange
            var notExistedCardId = ObjectId.GenerateNewId().ToString();
            var updateCardRequest = new UpdateCardRequest(notExistedCardId, "Test New Name", BoardCardType.Done);
            var expectedMessage = string.Format(ContractsMessages.Data_Not_exist, DomainMetadata.Card);

            //Act
            Func<Task> act = async () => await _updateCardUseCase.Handle(updateCardRequest, CancellationToken.None);

            //Assert
            await act.Should().ThrowAsync<BuildingBlocks.Application.Exceptions.ApplicationException>().Where(e => e.Message.Equals(expectedMessage));
        }



        #endregion

        #region Fixture

        protected override void TestClassFixtureSetup()
        {
            _updateCardUseCase = new UpdateCardUseCase(BoardAggregateRepository, MessageBus, InMemoryBus);
        }

        #endregion
    }
}
