using MongoDB.Bson;
using System;


namespace TaskoMask.Domain.Core.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            id = ObjectId.GenerateNewId().ToString();
        }

        public CreationTime CreationTime { get; private set; }


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

        private string id { get; set; }
    }
}
