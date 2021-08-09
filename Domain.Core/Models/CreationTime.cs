using System;
using System.Collections.Generic;

namespace TaskoMask.Domain.Core.Models
{
    public class CreationTime : ValueObject
    {
        #region Properties

        public DateTime CreateDateTime { get; private set; }
        public DateTime ModifiedDateTime { get; private set; }
        public int CreateDay { get; private set; }
        public int CreateMonth { get; private set; }
        public int CreateYear { get; private set; }

        #endregion

        #region Ctor

        public CreationTime()
        {
            CreateDateTime = DateTime.Now;
            ModifiedDateTime = CreateDateTime;
            CreateDay = CreateDateTime.Day;
            CreateMonth = CreateDateTime.Month;
            CreateYear = CreateDateTime.Year;
        }

        #endregion

        #region  Methods

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CreateDateTime;
            yield return ModifiedDateTime;
            yield return CreateDay;
            yield return CreateMonth;
            yield return CreateYear;
        }


        public void UpdateModifiedDateTime()
        {
            ModifiedDateTime = DateTime.Now;
        }

        #endregion
    }
}