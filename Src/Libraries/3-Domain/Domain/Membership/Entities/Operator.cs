using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Core.ValueObjects;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.Membership.Entities
{
    /// <summary>
    /// opertors of admin panel
    /// </summary>
    public class Operator : BaseUser
    {
        #region Fields


        #endregion

        #region Ctors

        private Operator(UserIdentity identity, UserAuthentication authentication)
            : base(identity, authentication)
        {
            CheckInvariants();
        }



        #endregion

        #region Properties

        public string[] RolesId { get; set; }

        #endregion

        #region Public Methods



        ///// <summary>
        ///// 
        ///// </summary>
        public static Operator Create(UserIdentity identity, UserAuthentication authentication)
        {
            return new Operator(identity,authentication);
        }



        ///// <summary>
        ///// 
        ///// </summary>
        public void Update(UserDisplayName displayName, UserEmail email, UserPhoneNumber phoneNumber, UserName userName)
        {
            UpdateIdentity(displayName, email, phoneNumber);
            UpdateAuthenticationUserName(userName);
            base.Update();

            CheckInvariants();
        }



        /// <summary>
        /// 
        /// </summary>
        public override void SetPassword(string password, IEncryptionService encryptionService)
        {
            base.SetPassword(password, encryptionService);
            CheckInvariants();
        }


        /// <summary>
        /// 
        /// </summary>
        public override void ChangePassword(string oldPassword, string newPassword, IEncryptionService encryptionService)
        {
            base.ChangePassword(oldPassword, newPassword, encryptionService);
            CheckInvariants();
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
            CheckInvariants();
        }



        /// <summary>
        /// 
        /// </summary>
        public override void SoftDelete()
        {
            base.SoftDelete();
            CheckInvariants();
        }



        /// <summary>
        /// 
        /// </summary>
        public override void Recycle()
        {
            base.Recycle();
            CheckInvariants();
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateRoles(string[] rolesId)
        {
            RolesId = rolesId;
            base.Update();
            CheckInvariants();
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

            if (Identity.Email.Value.ToLower().Equals(Authentication.UserName.Value.ToLower()))
                throw new DomainException(DomainMessages.UserName_And_Email_Cannot_Be_The_Same);

            if (string.IsNullOrEmpty(Identity.PhoneNumber.Value))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(UserPhoneNumber)));
        }


        #endregion
    }
}
