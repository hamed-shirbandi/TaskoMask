using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.DomainModel.Workspace.Boards.ValueObjects.Cards;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Core.Exceptions;

namespace TaskoMask.Domain.DomainModel.Workspace.Boards.Entities
{
    public class Card : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        private Card(string name, BoardCardType type)
        {
            Name = CardName.Create(name);
            Type = CardType.Create(type);

            CheckPolicies();
        }

        #endregion

        #region Properties


        public CardName Name { get; private set; }
        public CardType Type { get; private set; }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public static Card Create(string name, BoardCardType type)
        {
            return new Card(name, type);
        }



        /// <summary>
        /// 
        /// </summary>
        public void Update(string name, BoardCardType type)
        {
            Name = CardName.Create(name);
            Type = CardType.Create(type);
            base.UpdateModifiedDateTime();

            CheckPolicies();
        }



        /// <summary>
        /// 
        /// </summary>
        public new void Delete()
        {
            base.Delete();
            base.UpdateModifiedDateTime();

        }



        /// <summary>
        /// 
        /// </summary>
        public new void Recycle()
        {
            base.Recycle();
            base.UpdateModifiedDateTime();

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
