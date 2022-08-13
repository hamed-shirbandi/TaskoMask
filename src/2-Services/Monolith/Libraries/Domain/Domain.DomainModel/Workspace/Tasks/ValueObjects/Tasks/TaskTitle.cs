﻿using System.Collections.Generic;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.DomainModel.Workspace.Tasks.ValueObjects.Tasks
{
    public class TaskTitle : BaseValueObject
    {
        #region Properties

        public string Value { get; private set; }


        #endregion

        #region Ctors

        public TaskTitle(string value)
        {
            Value = value;

            CheckPolicies();
        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static TaskTitle Create(string value)
        {
            return new TaskTitle(value);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(TaskTitle)));

            if (Value.Length< DomainConstValues.Task_Title_Min_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(TaskTitle), DomainConstValues.Task_Title_Min_Length, DomainConstValues.Task_Title_Max_Length));

            if (Value.Length > DomainConstValues.Task_Title_Max_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(TaskTitle), DomainConstValues.Task_Title_Min_Length, DomainConstValues.Task_Title_Max_Length));
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
