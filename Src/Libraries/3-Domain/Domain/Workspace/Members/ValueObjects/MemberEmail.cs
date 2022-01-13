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
    public class MemberEmail : BaseValueObject
    {
        #region Properties

        public string Value { get; private set; }


        #endregion

        #region Ctors

        private MemberEmail(string value)
        {
            Value = value;

            CheckPolicies();
        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static MemberEmail Create(string value)
        {
            return new MemberEmail(value);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(MemberEmail)));

            if (Value.Length < DomainConstValues.Member_Email_Min_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(MemberEmail), DomainConstValues.Member_Email_Min_Length, DomainConstValues.Member_Email_Max_Length));

            if (Value.Length > DomainConstValues.Member_Email_Max_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(MemberEmail), DomainConstValues.Member_Email_Min_Length, DomainConstValues.Member_Email_Max_Length));

            if (EmailValidator.IsValid(Value))
                throw new DomainException(DomainMessages.Invalid_Email_Address);

            //TODO should be unique

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
