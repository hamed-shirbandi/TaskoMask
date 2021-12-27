using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Domain.Core.Models
{

    /// <summary>
    ///
    /// </summary>
    public class BaseEntity
    {
        #region Fields

        private string id;
        private List<DomainNotification> validationErrors;
        private List<IDomainEvent> domainEvents;

        #endregion

        #region Ctors

        public BaseEntity()
        {
            id = ObjectId.GenerateNewId().ToString();
            validationErrors = new List<DomainNotification>();
            CreationTime = new CreationTime();
        }


        #endregion

        #region Properties

        public string Id
        {
            get { return id; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    id = ObjectId.GenerateNewId().ToString();
                else
                    id = value;
            }
        }

        public bool IsDeleted { get; set; }
        public CreationTime CreationTime { get; private set; }

        [BsonIgnore]
        public IReadOnlyCollection<DomainNotification> ValidationErrors => validationErrors ?? new List<DomainNotification>();
        [BsonIgnore]
        public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents?.AsReadOnly();



        #endregion

        #region Public Methods


        /// <summary>
        /// Clear domain events
        /// </summary>
        public void ClearDomainEvents()
        {
            domainEvents?.Clear();
        }



        /// <summary>
        /// 
        /// </summary>
        public void Delete()
        {
            IsDeleted = true;
        }


        #endregion


        #region Protected Methods



        /// <summary>
        /// 
        /// </summary>
        protected virtual void Update()
        {
            CreationTime.UpdateModifiedDateTime();
        }



        /// <summary>
        /// 
        /// </summary>
        protected void AddValidationError(string errorMessage)
        {
            validationErrors ??= new List<DomainNotification>();

            validationErrors.Add(new DomainNotification(key: this.GetType().Name, value: errorMessage));
        }




        /// <summary>
        /// Add domain event
        /// </summary>
        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            domainEvents = domainEvents ?? new List<IDomainEvent>();
            this.domainEvents.Add(domainEvent);
        }





        #endregion

        #region Private Methods


        #endregion

    }
}
