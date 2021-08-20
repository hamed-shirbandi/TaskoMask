using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Domain.Core.Models
{

    /// <summary>
    ///
    /// </summary>
    public class BaseEntity
    {
        #region Fields

        private string id { get; set; }
        private List<DomainNotification> validationErrors;

        #endregion

        #region Ctors

        public BaseEntity()
        {
            id = ObjectId.GenerateNewId().ToString();
            validationErrors = new List<DomainNotification>();
        }


        #endregion

        #region Properties

        public string Id
        {
            get { return id; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    id = ObjectId.GenerateNewId().ToString();
                else
                    id = value;
            }
        }

        public CreationTime CreationTime { get; private set; }

        [BsonIgnore]
        public IReadOnlyCollection<DomainNotification> ValidationErrors => validationErrors ?? new List<DomainNotification>();



        #endregion

        #region Public Methods






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


        #endregion

        #region Private Methods


        #endregion

    }
}
