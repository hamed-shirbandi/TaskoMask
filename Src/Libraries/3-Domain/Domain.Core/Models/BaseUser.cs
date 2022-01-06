using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Core.ValueObjects;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.Core.Models
{
    public abstract class BaseUser : BaseAggregate
    {
        #region Ctors

        public BaseUser(UserIdentity identity, UserAuthentication authentication)
        {
            Identity = identity;
            Authentication = authentication;

            CheckPolicies();
        }


        #endregion

        #region Properties


        public UserIdentity Identity { get; private set; }
        public UserAuthentication Authentication { get; private set; }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsValidPassword(string password, IEncryptionService encryptionService)
        {
            return Authentication.IsValidPassword(password, encryptionService);
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual void SetPassword(string password, IEncryptionService encryptionService)
        {
            Authentication.SetPassword(password, encryptionService);
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual void ChangePassword(string oldPassword, string newPassword, IEncryptionService encryptionService)
        {
            Authentication.ChangePassword(oldPassword, newPassword, encryptionService);
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual void SetIsActive(bool isActive)
        {
             Authentication.SetIsActive(isActive);
        }

        #endregion

        #region Protected Methods



        /// <summary>
        /// 
        /// </summary>
        protected void UpdateIdentity(UserDisplayName displayName, UserEmail email, UserPhoneNumber phoneNumber)
        {
            Identity = Identity.Update(displayName, email, phoneNumber);
        }




        /// <summary>
        /// 
        /// </summary>
        protected void UpdateAuthenticationUserName(UserName userName)
        {
            Authentication = Authentication.UpdateUserName(userName);
        }






        #endregion

        #region Private Methods


        private void CheckPolicies()
        {
            if (Authentication == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Authentication)));

            if (Identity == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Identity)));
        }

        #endregion
    }
}
