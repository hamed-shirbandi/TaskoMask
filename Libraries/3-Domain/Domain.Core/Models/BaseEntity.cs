using MongoDB.Bson;
using System;

namespace TaskoMask.Domain.Core.Models
{
    public abstract class BaseEntity
    {
        #region Fields & Properties


        public DateTime CreateDateTime { get; set; }

        public DateTime ModifiedDateTime { get; set; }


        public string Id
        {
            get => id;
            set => id = string.IsNullOrEmpty(value) ?
                ObjectId.GenerateNewId().ToString() :
                value;
        }


        private string id { get; set; }


        #endregion


        #region Constructors


        protected BaseEntity()
        {
            id = ObjectId.GenerateNewId().ToString();
            CreateDateTime = DateTime.Now;
            ModifiedDateTime = DateTime.Now;
        }


        #endregion
    }
}