using AutoMapper;
using NSubstitute;
using TaskoMask.Application.Core.Bus;
using TaskoMask.Application.Core.Notifications;

namespace TaskoMask.Application.Tests.Unit.TestData
{
    public class TestsBase
    {

        protected IInMemoryBus _dummyInMemoryBus;
        protected IMapper _dummyIMapper;
        protected IDomainNotificationHandler _dummyDomainNotificationHandler;

        public TestsBase()
        {
            _dummyInMemoryBus = Substitute.For<IInMemoryBus>();
            _dummyIMapper = Substitute.For<IMapper>();
            _dummyDomainNotificationHandler = Substitute.For<IDomainNotificationHandler>();
        }

    }
}
