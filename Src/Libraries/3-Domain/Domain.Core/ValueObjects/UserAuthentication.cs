using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;
using System.Collections.Generic;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.Core.ValueObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class UserAuthentication : BaseValueObject
    {
        #region Fields


        #endregion

        #region Ctors

        public UserAuthentication(UserName userName)
        {
            UserName = userName;
            IsActive = UserIsActive.Create(true);

            CheckPolicies();
        }



        #endregion

        #region Properties

        public UserName UserName { get; private set; }
        public UserPassword Password { get; private set; }
        public UserIsActive IsActive { get; private set; }

        #endregion

        #region  Methods



        /// <summary>
        /// 
        /// </summary>
        public UserAuthentication UpdateUserName(UserName userName)
        {
            return new UserAuthentication(userName);
        }



        /// <summary>
        /// 
        /// </summary>
        public void SetPassword(string password, IEncryptionService encryptionService)
        {
            Password = UserPassword.Create(password, encryptionService);
        }


        /// <summary>
        /// 
        /// </summary>
        public void ChangePassword(string oldPassword, string newPassword, IEncryptionService encryptionService)
        {
            var isvalidOldPassword = Password.IsValidPassword(oldPassword, encryptionService);
            if (!isvalidOldPassword)
                throw new DomainException(DomainMessages.Incorrect_Old_Password);

            SetPassword(newPassword, encryptionService);
        }



        /// <summary>
        /// 
        /// </summary>
        public bool IsValidPassword(string password, IEncryptionService encryptionService)
        {
            return Password.IsValidPassword(password, encryptionService);
        }



        /// <summary>
        /// 
        /// </summary>
        public void SetIsActive(bool isActive)
        {
            IsActive = UserIsActive.Create(isActive);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserName;
            yield return Password;
            yield return IsActive;
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            if (IsActive == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(IsActive)));

            if (UserName == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(UserName)));
        }


        #endregion
    }
}
