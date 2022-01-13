using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Workspace.Members.Events;
using TaskoMask.Domain.Workspace.Members.ValueObjects;

namespace TaskoMask.Domain.Workspace.Members.Entities
{
    /// <summary>
    /// Members are those who manage their tasks in this system
    /// </summary>
    public class Member : BaseAggregate
    {
        #region Fields


        #endregion

        #region Ctors

        private Member(MemberDisplayName displayName, MemberEmail email)
        {
            DisplayName = displayName;
            Email = email;

            AddDomainEvent(new MemberCreatedEvent(Id, displayName.Value, email.Value));
        }



        #endregion

        #region Properties

        public MemberDisplayName DisplayName { get; private set; }
        public MemberEmail Email { get; private set; }

        #endregion

        #region Public Methods



        ///// <summary>
        ///// 
        ///// </summary>
        public static Member Create(MemberDisplayName displayName, MemberEmail email)
        {
            return new Member(displayName, email);
        }



        ///// <summary>
        /////  
        ///// </summary>
        public void Update(MemberDisplayName displayName, MemberEmail email)
        {
            DisplayName = displayName;
            Email = email;
            base.Update();

            AddDomainEvent(new MemberUpdatedEvent(Id, displayName.Value, email.Value));
        }




        /// <summary>
        /// 
        /// </summary>
        public override void SoftDelete()
        {
            base.SoftDelete();
            AddDomainEvent(new MemberDeletedEvent(Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public override void Recycle()
        {
            base.Recycle();
            AddDomainEvent(new MemberRecycledEvent(Id));
        }



        #endregion

        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        protected override void CheckInvariants()
        {
            if (DisplayName == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(DisplayName)));

            if (Email == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Email)));

        }


        #endregion
    }
}
