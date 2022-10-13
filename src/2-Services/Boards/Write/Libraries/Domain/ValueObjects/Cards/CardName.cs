using System;
using System.Collections.Generic;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Boards.Write.Domain.ValueObjects.Cards
{
    public class CardName : BaseValueObject
    {
        #region Properties

        public string Value { get; private set; }


        #endregion

        #region Ctors

        public CardName(string value)
        {
            Value = value;

            CheckPolicies();
        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static CardName Create(string value)
        {
            return new CardName(value);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DomainException(string.Format(ContractsMetadata.Required, nameof(CardName)));

            if (Value.Length< DomainConstValues.Card_Name_Min_Length)
                throw new DomainException(string.Format(ContractsMetadata.Length_Error, nameof(CardName), DomainConstValues.Card_Name_Min_Length, DomainConstValues.Card_Name_Max_Length));

            if (Value.Length > DomainConstValues.Card_Name_Max_Length)
                throw new DomainException(string.Format(ContractsMetadata.Length_Error, nameof(CardName), DomainConstValues.Card_Name_Min_Length, DomainConstValues.Card_Name_Max_Length));

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
