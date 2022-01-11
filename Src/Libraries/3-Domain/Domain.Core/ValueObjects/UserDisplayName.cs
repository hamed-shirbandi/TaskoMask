using System.Collections.Generic;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.Core.ValueObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class UserDisplayName : BaseValueObject
    {
        #region Properties

        public string Value { get; private set; }


        #endregion

        #region Ctors

        private UserDisplayName(string value)
        {
            Value = value;

            CheckPolicies();
        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static UserDisplayName Create(string value)
        {
            return new UserDisplayName(value);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(UserDisplayName)));
           
            if (Value.Length < DomainConstValues.Member_DisplayName_Min_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(UserDisplayName), DomainConstValues.Member_DisplayName_Min_Length, DomainConstValues.Member_DisplayName_Max_Length));

            if (Value.Length > DomainConstValues.Member_DisplayName_Max_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(UserDisplayName), DomainConstValues.Member_DisplayName_Min_Length, DomainConstValues.Member_DisplayName_Max_Length));

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
