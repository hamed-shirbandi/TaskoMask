using TaskoMask.Services.Monolith.Domain.Core.Exceptions;
using TaskoMask.Services.Monolith.Domain.Core.Models;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Domain.DataModel.Entities
{
    public class Activity : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Activity( )
        {
        }

        public string TaskId { get; set; }
        public string Description { get; set; }

    }
}
