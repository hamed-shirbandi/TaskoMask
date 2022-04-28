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

        #region Ctor

        //Run before each test method
        public OwnerCommandHandlersUnitTests()
        {
            FixtureSetup();
        }



        #endregion


        #region Test Methods






        #endregion

        #region Private Methods



        private void FixtureSetup()
        {
            _owners = GetOwnersList();

            _ownerAggregateRepository = Substitute.For<IOwnerAggregateRepository>();
            _ownerAggregateRepository.CreateAsync(Arg.Any<Owner>()).Returns(async args => await AddNewOwner((Owner)args[0]));

            _ownerCommandHandlers = new OwnerCommandHandlers(_ownerAggregateRepository, _dummyInMemoryBus);

        }



        private List<Owner> GetOwnersList()
        {
            return new List<Owner>
            {

            };
        }



        private async Task AddNewOwner(Owner owner)
        {
            _owners.Add(owner);
        }



        #endregion
    }
}
