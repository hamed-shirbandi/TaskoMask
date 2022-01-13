using System.Collections.Generic;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.Workspace.Members.ValueObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class MemberDisplayName : BaseValueObject
    {
        #region Properties

        public string Value { get; private set; }


        #endregion

        #region Ctors

        private MemberDisplayName(string value)
        {
            Value = value;

            CheckPolicies();
        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static MemberDisplayName Create(string value)
        {
            return new MemberDisplayName(value);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(MemberDisplayName)));
           
            if (Value.Length < DomainConstValues.Member_DisplayName_Min_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(MemberDisplayName), DomainConstValues.Member_DisplayName_Min_Length, DomainConstValues.Member_DisplayName_Max_Length));

            if (Value.Length > DomainConstValues.Member_DisplayName_Max_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(MemberDisplayName), DomainConstValues.Member_DisplayName_Min_Length, DomainConstValues.Member_DisplayName_Max_Length));

            //TODO should only contain alphabet and space ...
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
