using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.DataModel.Entities
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
