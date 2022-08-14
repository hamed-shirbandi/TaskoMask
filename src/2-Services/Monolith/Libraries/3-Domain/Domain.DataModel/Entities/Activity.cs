using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using MongoDB.Bson;

namespace TaskoMask.Services.Monolith.Domain.DataModel.Entities
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
