using System;
using System.Collections.Generic;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.Workspace.Organizations.ValueObjects
{
    public class ProjectDescription : BaseValueObject
    {
        #region Properties

        public string Value { get; private set; }


        #endregion

        #region Ctors

        public ProjectDescription(string value)
        {
            Value = value;

            CheckPolicies();
        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static ProjectDescription Create(string value)
        {
            return new ProjectDescription(value);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(ProjectDescription)));

            if (Value.Length < DomainConstValues.Project_Description_Min_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(ProjectName), DomainConstValues.Project_Description_Min_Length, DomainConstValues.Project_Description_Max_Length));

            if (Value.Length > DomainConstValues.Project_Description_Max_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(ProjectName), DomainConstValues.Project_Description_Min_Length, DomainConstValues.Project_Description_Max_Length));

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
