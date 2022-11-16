using NSubstitute;
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



        /// <summary>
        /// Run before each test method
        /// </summary>
        public TestsBaseFixture()
        {
            FixtureSetup();
        }



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
            OwnerAggregateRepository = Substitute.For<IOwnerAggregateRepository>();
            OwnerValidatorService = Substitute.For<IOwnerValidatorService>();


            Owners = OwnerObjectMother.GenerateOwnerList(OwnerValidatorService);

            OwnerAggregateRepository.GetByIdAsync(Arg.Is<string>(x => Owners.Any(u => u.Id == x))).Returns(args => Owners.First(u => u.Id == (string)args[0]));
            OwnerAggregateRepository.CreateAsync(Arg.Any<Owner>()).Returns(async args => Owners.Add((Owner)args[0]));
            OwnerAggregateRepository.UpdateAsync(Arg.Is<Owner>(x => Owners.Any(u => u.Id == x.Id))).Returns(async args =>
            {
                var existUser = Owners.FirstOrDefault(u => u.Id == ((Owner)args[0]).Id);
                if (existUser != null)
                {
                    Owners.Remove(existUser);
                    Owners.Add(((Owner)args[0]));
                }
            });

            OwnerValidatorService.OwnerHasUniqueEmail(ownerId: Arg.Any<string>(), email: Arg.Any<string>()).Returns(arg => !Owners.Any(o => o.Id != (string)arg[0] && o.Email.Value == (string)arg[1]));
        }



        /// <summary>
        /// Each test class should setup its own fixture
        /// </summary>
        protected abstract void TestClassFixtureSetup();

    }
}