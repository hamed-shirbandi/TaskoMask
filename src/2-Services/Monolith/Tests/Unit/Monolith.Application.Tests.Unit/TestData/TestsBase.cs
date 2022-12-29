using AutoMapper;
using NSubstitute;
using TaskoMask.BuildingBlocks.Application.Bus;
using TaskoMask.BuildingBlocks.Application.Notifications;
using TaskoMask.BuildingBlocks.Test.TestBase;

namespace TaskoMask.Services.Monolith.Application.Tests.Unit.TestData
{
    public abstract class TestsBase : UnitTestsBase
    {

        protected IMessageBus _messageBus;
        protected IInMemoryBus _inMemoryBus;
        protected IMapper _iMapper;
        protected INotificationHandler _domainNotificationHandler;



        /// <summary>
        /// Run before each test method
        /// </summary>
        public TestsBase()
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
            _messageBus = Substitute.For<IMessageBus>();
            _inMemoryBus = Substitute.For<IInMemoryBus>();
            _iMapper = Substitute.For<IMapper>();
            _domainNotificationHandler = Substitute.For<INotificationHandler>();
        }



        /// <summary>
        /// Each test class should setup its fixture
        /// </summary>
        protected abstract void TestClassFixtureSetup();


    }
}
