using TaskoMask.BuildingBlocks.Domain.Models;
using MongoDB.Bson;

namespace TaskoMask.Services.Tasks.Read.Api.Domain
{
    public class Activity : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Activity( )
        {
            SetId(ObjectId.GenerateNewId().ToString());
        }

        public string TaskId { get; set; }
        public string Description { get; set; }

    }
}
