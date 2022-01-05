using System;
using System.Collections.Generic;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Core.ValueObjects
{
    /// <summary>
    ///
    /// </summary>
    public class CreationTime : BaseValueObject
    {
        #region Properties

        public DateTime CreateDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }
        public int CreateDay { get; private set; }
        public int CreateMonth { get; private set; }
        public int CreateYear { get; private set; }

        #endregion

        #region Ctors

        private CreationTime()
        {
            CreateDateTime = DateTime.Now;
            ModifiedDateTime = CreateDateTime;
            CreateDay = CreateDateTime.Day;
            CreateMonth = CreateDateTime.Month;
            CreateYear = CreateDateTime.Year;
        }



        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static CreationTime Create()
        {
            return new CreationTime();
        }



        /// <summary>
        /// Value objects are immutable.
        /// Changing it creates a new object
        /// </summary>
        public CreationTime UpdateModifiedDateTime()
        {
            return new CreationTime
            {
                ModifiedDateTime = DateTime.Now,
                CreateDateTime = this.CreateDateTime,
                CreateDay = this.CreateDateTime.Day,
                CreateMonth = this.CreateDateTime.Month,
                CreateYear = this.CreateDateTime.Year,
            };
        }



        /// <summary>
        /// 
        /// </summary>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CreateDateTime;
            yield return ModifiedDateTime;
            yield return CreateDay;
            yield return CreateMonth;
            yield return CreateYear;
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            
        }





        #endregion
    }
}