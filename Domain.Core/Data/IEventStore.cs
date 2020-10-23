using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Domain.Core.Events;

namespace TaskoMask.Domain.Core.Data
{
    public interface IEventStore
    {
        void Save<T>(T eventData) where T : StoredEvent;
    }
}
