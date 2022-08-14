using System;
using System.Collections.Generic;
using TaskoMask.Services.Monolith.Domain.Core.Exceptions;
using TaskoMask.Services.Monolith.Domain.Core.Models;
using TaskoMask.Services.Monolith.Domain.Share.Helpers;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.ValueObjects.Projects
{
    public class ProjectName : BaseValueObject
    {
        #region Properties

        public string Value { get; private set; }


        #endregion

        #region Ctors

        public ProjectName(string value)
        {
            Value = value;

            CheckPolicies();
        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static ProjectName Create(string value)
        {
            return new ProjectName(value);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(ProjectName)));

            if (Value.Length < DomainConstValues.Project_Name_Min_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(ProjectName), DomainConstValues.Project_Name_Min_Length, DomainConstValues.Project_Name_Max_Length));

            if (Value.Length > DomainConstValues.Project_Name_Max_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(ProjectName), DomainConstValues.Project_Name_Min_Length, DomainConstValues.Project_Name_Max_Length));

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
