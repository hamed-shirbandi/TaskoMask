using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using TaskoMask.Domain.Core.Events;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Domain.Core.Models
{

    /// <summary>
    ///
    /// </summary>
    public abstract class BaseEntity
    {
        #region Fields

        private List<DomainNotification> validationErrors;
        private List<IDomainEvent> domainEvents;

        #endregion

        #region Ctors

        public BaseEntity()
        {
            Id = ObjectId.GenerateNewId().ToString();
            validationErrors = new List<DomainNotification>();
            CreationTime = CreationTime.Create();
        }


        #endregion

        #region Properties

        public string Id { get; private set; }

        public bool IsDeleted { get; private set; }
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



        #endregion

        #region Protected Methods



        /// <summary>
        /// 
        /// </summary>
        protected virtual void Update()
        {
            CreationTime = CreationTime.UpdateModifiedDateTime();
        }



        /// <summary>
        /// 
        /// </summary>
        protected virtual void Delete()
        {
            IsDeleted = true;
        }



        /// <summary>
        /// 
        /// </summary>
        protected virtual void Recycle()
        {
            IsDeleted = false;
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

            CheckInvariants();

            if (IsStateValid())
            {
                domainEvents = domainEvents ?? new List<IDomainEvent>();
                this.domainEvents.Add(domainEvent);
            }

        }



        /// <summary>
        /// Check invariants for each entity
        /// Invariants are kind of validation that made the entity in wrang state
        /// </summary>
        protected abstract void CheckInvariants();


        #endregion

        #region Private Methods




        /// <summary>
        /// Check if there is not any validation error made by CheckInvariants and CheckPolicies
        /// </summary>
        private bool IsStateValid()
        {
            return validationErrors.Count == 0;
        }



        #endregion

    }
}
