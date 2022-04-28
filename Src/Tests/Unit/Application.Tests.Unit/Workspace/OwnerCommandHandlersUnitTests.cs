using FluentAssertions;
using MongoDB.Bson;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Share.Resources;
using TaskoMask.Application.Tests.Unit.TestData;
using TaskoMask.Application.Workspace.Owners.Commands.Handlers;
using TaskoMask.Application.Workspace.Owners.Commands.Models;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Data;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;
using Xunit;

namespace TaskoMask.Application.Tests.Unit.Workspace
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
        public async Task Create_Owner_Command_Is_Worked_Properly()
        {
            //Arrange
            var createOwnerCommand = new CreateOwnerCommand(ObjectId.GenerateNewId().ToString(), "Test_DisplayName", "Test@email.com", "Test_Password");

            //Act
            var result = await _ownerCommandHandlers.Handle(createOwnerCommand, CancellationToken.None);

            //Assert
            result.EntityId.Should().NotBeNullOrEmpty();
            result.Message.Should().Be(ApplicationMessages.Create_Success);
            var createdUser = _owners.FirstOrDefault(u => u.Id == result.EntityId);
            createdUser.DisplayName.Value.Should().Be(createOwnerCommand.DisplayName);

        }



        #endregion

        #region Private Methods



        protected override void FixtureSetup()
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
            _ownerCommandHandlers = new OwnerCommandHandlers(_ownerAggregateRepository, _dummyInMemoryBus);

        }

        #endregion
    }
}
