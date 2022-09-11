using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Services.Monolith.Application.Tests.Unit.TestData;
using TaskoMask.Services.Monolith.Application.Workspace.Owners.Commands.Handlers;
using TaskoMask.Services.Monolith.Application.Workspace.Owners.Commands.Models;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Data;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Events.Owners;
using Xunit;

namespace TaskoMask.Services.Monolith.Application.Tests.Unit.Workspace
{
    public class OwnerCommandHandlersUnitTests : TestsBase
    {

        #region Fields

        private IOwnerAggregateRepository _ownerAggregateRepository;
        private OwnerCommandHandlers _ownerCommandHandlers;
        private List<Owner> _owners;


        #endregion

        #region Test Methods




        [Fact]
        public async Task Owner_Is_Registered()
        {
            //Arrange
            var createOwnerCommand = new RegisterOwnerCommand("Test_DisplayName", "Test@email.com", "Test_Password");

            //Act
            var result = await _ownerCommandHandlers.Handle(createOwnerCommand, CancellationToken.None);

            //Assert
            var createdUser = _owners.FirstOrDefault(u => u.Id == result.EntityId);
            createdUser.Email.Value.Should().Be(createOwnerCommand.Email);
            await _inMemoryBus.Received(1).Publish(Arg.Any<OwnerRegisteredEvent>());
        }




        [Fact]
        public async Task Owner_Profile_Is_Updated()
        {
            //Arrange
            var ownerToUpdate = _owners.First();
            var updateOwnerCommand = new UpdateOwnerProfileCommand(ownerToUpdate.Id, "New_DisplayName", "New@email.com");

            //Act
            var result = await _ownerCommandHandlers.Handle(updateOwnerCommand, CancellationToken.None);

            //Assert
            result.EntityId.Should().Be(ownerToUpdate.Id);
            ownerToUpdate.Email.Value.Should().Be(updateOwnerCommand.Email);
            await _inMemoryBus.Received(1).Publish(Arg.Any<OwnerProfileUpdatedEvent>());
        }



        #endregion

        #region Private Methods



        protected override void TestClassFixtureSetup()
        {
            _owners = DataGenerator.GenerateOwnerList();

            _ownerAggregateRepository = Substitute.For<IOwnerAggregateRepository>();
            _ownerAggregateRepository.GetByIdAsync(Arg.Is<string>(x => _owners.Any(u => u.Id == x))).Returns(args => _owners.First(u => u.Id == (string)args[0]));
            _ownerAggregateRepository.CreateAsync(Arg.Any<Owner>()).Returns(async args => _owners.Add((Owner)args[0]));
            _ownerAggregateRepository.UpdateAsync(Arg.Is<Owner>(x => _owners.Any(u => u.Id == x.Id))).Returns(async args =>
            {
                var existUser = _owners.FirstOrDefault(u => u.Id == ((Owner)args[0]).Id);
                if (existUser != null)
                {
                    _owners.Remove(existUser);
                    _owners.Add(((Owner)args[0]));
                }
            });

            _ownerCommandHandlers = new OwnerCommandHandlers(_ownerAggregateRepository, _inMemoryBus);

        }



        #endregion
    }
}
