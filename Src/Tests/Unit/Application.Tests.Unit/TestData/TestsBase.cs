using AutoMapper;
using NSubstitute;
using System;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Core.Notifications;

namespace TaskoMask.Application.Tests.Unit.TestData
{
    public abstract class TestsBase : IDisposable
    {

        protected IInMemoryBus _dummyInMemoryBus;
        protected IMapper _dummyIMapper;
        protected IDomainNotificationHandler _dummyDomainNotificationHandler;


        /// <summary>
        /// Run before each test method
        /// </summary>
        public TestsBase()
        {

            _dummyInMemoryBus = Substitute.For<IInMemoryBus>();
            _dummyIMapper = Substitute.For<IMapper>();
            _dummyDomainNotificationHandler = Substitute.For<IDomainNotificationHandler>();

            FixtureSetup();

        }


        /// <summary>
        /// Each test class should setup its fixture
        /// </summary>
        protected abstract void FixtureSetup();



        /// <summary>
        /// Run after each test method
        /// </summary>
        public void Dispose()
        {

        }


    }
}
