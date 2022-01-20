using System;
using System.Collections.Generic;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.WriteModel.Workspace.Tasks.ValueObjects.Tasks
{
    public class TaskDescription : BaseValueObject
    {
        #region Properties

        public string Value { get; private set; }


        #endregion

        #region Ctors

        public TaskDescription(string value)
        {
            Value = value;

            CheckPolicies();
        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static TaskDescription Create(string value)
        {
            return new TaskDescription(value);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(TaskDescription)));
          
            if (Value.Length < DomainConstValues.Task_Description_Min_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(TaskDescription), DomainConstValues.Task_Description_Min_Length, DomainConstValues.Task_Description_Max_Length));

            if (Value.Length > DomainConstValues.Task_Description_Max_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(TaskDescription), DomainConstValues.Task_Description_Min_Length, DomainConstValues.Task_Description_Max_Length));
        }



        /// <summary>
        /// 
        /// </summary>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }


        #endregion

    }
}
