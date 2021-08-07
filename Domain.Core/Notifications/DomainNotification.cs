using System;

namespace TaskoMask.Domain.Core.Notifications
{
    public class DomainNotification
    {
        public Guid Id { get; private set; }
        
        
        /// <summary>
        /// group of notification messages
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// notification message
        /// </summary>
        public string Value { get; private set; }

        public DomainNotification(string key, string value)
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
        }
    }
}