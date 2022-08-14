using System.Collections.Generic;
using TaskoMask.Services.Monolith.Domain.Core.Exceptions;
using TaskoMask.Services.Monolith.Domain.Core.Models;
using TaskoMask.Services.Monolith.Domain.Share.Helpers;
using TaskoMask.Services.Monolith.Domain.Share.Resources;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.ValueObjects.Owners
{
    /// <summary>
    /// 
    /// </summary>
    public class OwnerEmail : BaseValueObject
    {
        #region Properties

        public string Value { get; private set; }


        #endregion

        #region Ctors

        private OwnerEmail(string value)
        {
            Value = value;

            CheckPolicies();
        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static OwnerEmail Create(string value)
        {
            return new OwnerEmail(value);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(OwnerEmail)));

            if (Value.Length < DomainConstValues.Owner_Email_Min_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(OwnerEmail), DomainConstValues.Owner_Email_Min_Length, DomainConstValues.Owner_Email_Max_Length));

            if (Value.Length > DomainConstValues.Owner_Email_Max_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(OwnerEmail), DomainConstValues.Owner_Email_Min_Length, DomainConstValues.Owner_Email_Max_Length));

            if (!EmailValidator.IsValid(Value))
                throw new DomainException(DomainMessages.Invalid_Email_Address);
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
