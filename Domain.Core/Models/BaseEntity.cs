using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskoMask.Domain.Core.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            id = ObjectId.GenerateNewId().ToString();
            CreateDateTime = DateTime.Now;
            ModifiedDateTime = DateTime.Now;
        }

        public DateTime CreateDateTime { get; set; }

        public DateTime ModifiedDateTime { get; set; }


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
