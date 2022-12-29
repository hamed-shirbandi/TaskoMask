﻿using FluentAssertions;
using TaskoMask.BuildingBlocks.Contracts.Enums;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Boards.Write.Application.UseCases.Cards.AddCard;
using TaskoMask.Services.Boards.Write.IntegrationTests.Fixtures;
using TaskoMask.Services.Boards.Write.IntegrationTests.TestData;
using Xunit;

namespace TaskoMask.Services.Boards.Write.IntegrationTests.UseCases.Cards
{
    [Collection(nameof(CardCollectionFixture))]
    public class AddCardTests
    {

        #region Fields

        private readonly CardCollectionFixture _fixture;

        #endregion

        #region Ctor

        public AddCardTests(CardCollectionFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region Test Methods


        [Fact]
        public async Task Card_Is_Added()
        {
            //Arrange
            var expectedBoard = BoardObjectMother.GetABoardWithACard(_fixture.BoardValidatorService);
            await _fixture.SeedBoardAsync(expectedBoard);

            var request = new AddCardRequest(boardId: expectedBoard.Id, name: "Test Name", type: BoardCardType.ToDo);
            var addCardUseCase = new AddCardUseCase(_fixture.BoardAggregateRepository, _fixture.MessageBus, _fixture.InMemoryBus);

            //Act
            var result = await addCardUseCase.Handle(request, CancellationToken.None);

            //Assert
            result.EntityId.Should().NotBeNull();
            result.Message.Should().Be(ContractsMessages.Create_Success);

            var updatedBoard = await _fixture.GetBoardAsync(expectedBoard.Id);
            var addedCard = updatedBoard.Cards.FirstOrDefault(c => c.Id == result.EntityId);
            addedCard.Name.Value.Should().Be(request.Name);
        }


        #endregion
    }
}