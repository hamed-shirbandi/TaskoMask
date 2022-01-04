using TaskoMask.Domain.Administration.Events;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;


namespace TaskoMask.Domain.Administration.Entities
{
    public class Permission : BaseEntity
    {
        public string DisplayName { get; set; }
        public string SystemName { get; set; }
        public string GroupName { get; set; }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckInvariants()
        {

        }


    }
}
