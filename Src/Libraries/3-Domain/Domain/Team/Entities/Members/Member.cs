using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Core.ValueObjects;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Team.Entities.Members.Events;
using TaskoMask.Domain.Team.Members.Events;

namespace TaskoMask.Domain.Team.Entities.Members
{
    /// <summary>
    /// Members are those who manage their tasks in this system
    /// </summary>
    public class Member : BaseUser
    {
        #region Fields


        #endregion

        #region Ctors

        private Member(UserIdentity identity, UserAuthentication authentication)
            : base(identity, authentication)
        {
            AddDomainEvent(new MemberCreatedEvent(Id, identity.DisplayName.Value, identity.Email.Value, authentication.UserName.Value));
        }



        #endregion

        #region Properties


        #endregion

        #region Public Methods



        ///// <summary>
        ///// 
        ///// </summary>
        public static Member Create(UserIdentity identity, UserAuthentication authentication)
        {
            return new Member(identity, authentication);
        }



        ///// <summary>
        /////  
        ///// </summary>
        public void Update(UserDisplayName displayName, UserEmail email, UserPhoneNumber phoneNumber)
        {
            UpdateIdentity(displayName, email, phoneNumber);
            UpdateAuthenticationUserName(UserName.Create(email.Value));
            base.Update();

            AddDomainEvent(new MemberUpdatedEvent(Id, Identity.DisplayName.Value, Identity.Email.Value, Authentication.UserName.Value));
        }



        /// <summary>
        /// 
        /// </summary>
        public override void SetPassword(string password, IEncryptionService encryptionService)
        {
            base.SetPassword(password, encryptionService);

            AddDomainEvent(new MemberPasswordSetEvent(Id, Authentication.Password.PasswordHash, Authentication.Password.PasswordSalt));
        }



        /// <summary>
        /// 
        /// </summary>
        public override void ChangePassword(string oldPassword, string newPassword, IEncryptionService encryptionService)
        {
            base.ChangePassword(oldPassword, newPassword, encryptionService);
            AddDomainEvent(new MemberPasswordSetEvent(Id, Authentication.Password.PasswordHash, Authentication.Password.PasswordSalt));
        }



        /// <summary>
        /// 
        /// </summary>
        public override bool IsValidPassword(string password, IEncryptionService encryptionService)
        {
            return base.IsValidPassword(password, encryptionService);
        }




        /// <summary>
        /// 
        /// </summary>
        public override void SetIsActive(bool isActive)
        {
            base.SetIsActive(isActive);
            AddDomainEvent(new MemberActivityStateChangedEvent(Id, Authentication.IsActive.Value));

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
            if (Authentication == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Authentication)));

            if (Identity == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Identity)));

            if (!Identity.Email.Value.ToLower().Equals(Authentication.UserName.Value.ToLower()))
                throw new DomainException(DomainMessages.UserName_And_Email_Must_Be_The_Same);
        }

     
        #endregion
    }
}
