using MongoDB.Bson;
using System;
using System.Collections.Generic;
using TaskoMask.Domain.Core.Notifications;

namespace TaskoMask.Domain.Core.Models
{
    public class BaseEntity
    {

        #region Fields

        private string id { get; set; }
        private List<DomainNotification> validationErrors;

        #endregion

        #region Ctor

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

        public IReadOnlyCollection<DomainNotification> ValidationErrors => validationErrors?.AsReadOnly();



        #endregion




        #region Public Methods



        public void AddValidationError(string errorMessage)
        {
            validationErrors.Add(new DomainNotification(key: this.GetType().Name, value: errorMessage));
        }




        #endregion


        #region Private Methods


        #endregion

    }
}
