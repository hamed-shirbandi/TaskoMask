using System;
using System.Collections.Generic;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.Workspace.Boards.ValueObjects.Cards
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
                throw new DomainException(string.Format(DomainMessages.Required, nameof(CardName)));

            if (Value.Length< DomainConstValues.Card_Name_Min_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(CardName), DomainConstValues.Card_Name_Min_Length, DomainConstValues.Card_Name_Max_Length));

            if (Value.Length > DomainConstValues.Card_Name_Max_Length)
                throw new DomainException(string.Format(DomainMessages.Length_Error, nameof(CardName), DomainConstValues.Card_Name_Min_Length, DomainConstValues.Card_Name_Max_Length));

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
