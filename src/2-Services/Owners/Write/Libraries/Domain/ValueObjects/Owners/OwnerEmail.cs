using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Resources;

namespace TaskoMask.Services.Owners.Write.Domain.ValueObjects.Owners
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
                throw new DomainException(string.Format(ContractsMetadata.Required, nameof(OwnerEmail)));

            if (Value.Length < DomainConstValues.Owner_Email_Min_Length)
                throw new DomainException(string.Format(ContractsMetadata.Length_Error, nameof(OwnerEmail), DomainConstValues.Owner_Email_Min_Length, DomainConstValues.Owner_Email_Max_Length));

            if (Value.Length > DomainConstValues.Owner_Email_Max_Length)
                throw new DomainException(string.Format(ContractsMetadata.Length_Error, nameof(OwnerEmail), DomainConstValues.Owner_Email_Min_Length, DomainConstValues.Owner_Email_Max_Length));

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
