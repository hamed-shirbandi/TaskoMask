using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Workspace.Boards.ValueObjects.Cards;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Core.Exceptions;

namespace TaskoMask.Domain.Workspace.Boards.Entities
{
    public class Card : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public Card(string name, BoardCardType type)
        {
            Name = CardName.Create(name);
            Type = CardType.Create(type);

            CheckPolicies();
        }

        #endregion

        #region Properties


        public CardName Name { get; set; }
        public CardType Type { get; set; }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public void Update(string name,  BoardCardType type)
        {
            Name = CardName.Create(name);
            Type = CardType.Create(type);
            base.UpdateModifiedDateTime();

            CheckPolicies();
        }

        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies()
        {
            if (Name == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Name)));

            if (Type == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Type)));

        }


        #endregion
    }
}
