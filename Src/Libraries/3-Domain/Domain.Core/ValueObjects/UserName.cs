using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.Core.ValueObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class UserName : BaseValueObject
    {
        #region Properties

        public string Value { get; private set; }


        #endregion

        #region Ctors

        private UserName(string value)
        {
            Value = value;

            CheckPolicies();
        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static UserName Create(string value)
        {
            return new UserName(value);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(UserName)));

            //for Members it uses Email for UserName
            //for Operators we consider this policy too
            if (Value.Length < DomainConstValues.Member_Email_Min_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(UserName), DomainConstValues.Member_Email_Min_Length, DomainConstValues.Member_Email_Max_Length));

            if (Value.Length > DomainConstValues.Member_Email_Max_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(UserName), DomainConstValues.Member_Email_Min_Length, DomainConstValues.Member_Email_Max_Length));


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
