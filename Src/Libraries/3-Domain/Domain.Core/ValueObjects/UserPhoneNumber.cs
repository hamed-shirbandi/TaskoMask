using System.Collections.Generic;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.Core.ValueObjects
{
    public class UserPhoneNumber : BaseValueObject
    {
        #region Properties

        public string Value { get; private set; }


        #endregion

        #region Ctors

        private UserPhoneNumber(string value)
        {
            Value = value;

            CheckPolicies();
        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static UserPhoneNumber Create(string value)
        {
            return new UserPhoneNumber(value);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            //if (!string.IsNullOrEmpty(Value))
            //    if (Value.Length != 11)
            //        throw new DomainException(string.Format(DomainMessages.Invalid_PhoneNumber, nameof(UserPhoneNumber)));


            //TODO should be a valid phoneNumber

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
