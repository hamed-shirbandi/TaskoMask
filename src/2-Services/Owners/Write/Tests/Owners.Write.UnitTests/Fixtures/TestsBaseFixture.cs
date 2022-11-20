﻿using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Test;
using TaskoMask.Services.Owners.Write.Domain.Data;
using TaskoMask.Services.Owners.Write.Domain.Entities;
using TaskoMask.Services.Owners.Write.Domain.Services;
using TaskoMask.Services.Owners.Write.UnitTests.TestData;

namespace TaskoMask.Services.Owners.Write.UnitTests.Fixtures
{
    public abstract class TestsBaseFixture : UnitTestsBase
    {

        protected IMessageBus MessageBus;
        protected IInMemoryBus InMemoryBus;
        protected IOwnerAggregateRepository OwnerAggregateRepository;
        protected IOwnerValidatorService OwnerValidatorService;
        protected List<Owner> Owners;



        ///// <summary>
        ///// 
        ///// </summary>
        protected override void FixtureSetup()
        {
            CommonFixtureSetup();

            TestClassFixtureSetup();
        }



        /// <summary>
        /// 
        /// </summary>
        private void CommonFixtureSetup()
        {
            MessageBus = Substitute.For<IMessageBus>();

            InMemoryBus = Substitute.For<IInMemoryBus>();

            Owners = OwnerObjectMother.GenerateOwnerList();

            OwnerValidatorService = Substitute.For<IOwnerValidatorService>();
            OwnerValidatorService.OwnerHasUniqueEmail(ownerId: Arg.Any<string>(), email: Arg.Any<string>()).Returns(args =>
            {
                return !Owners.Any(o => o.Id != (string)args[0] && o.Email.Value == (string)args[1]);
            });

            OwnerAggregateRepository = Substitute.For<IOwnerAggregateRepository>();
            OwnerAggregateRepository.GetByIdAsync(Arg.Is<string>(x => Owners.Any(o => o.Id == x))).Returns(args => Owners.First(u => u.Id == (string)args[0]));
            OwnerAggregateRepository.CreateAsync(Arg.Any<Owner>()).Returns(args => { Owners.Add((Owner)args[0]); return Task.CompletedTask; });
            OwnerAggregateRepository.UpdateAsync(Arg.Is<Owner>(x => Owners.Any(o => o.Id == x.Id))).Returns(args =>
            {
                var existOwner = Owners.FirstOrDefault(u => u.Id == ((Owner)args[0]).Id);
                if (existOwner != null)
                {
                    Owners.Remove(existOwner);
                    Owners.Add(((Owner)args[0]));
                }

                return Task.CompletedTask;
            });

        }



        /// <summary>
        /// Each test class should setup its own fixture
        /// </summary>
        protected abstract void TestClassFixtureSetup();

    }
}