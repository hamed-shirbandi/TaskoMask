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



        /// <summary>
        /// 
        /// </summary>
        private UserAuthentication()
        {
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
        /// Factory method for creating new object
        /// </summary>
        public static UserAuthentication Create(UserName userName)
        {
            return new UserAuthentication
            {
                IsActive = UserIsActive.Create(true),
                UserName = userName,
                Password=UserPassword.CreateDefault()
            };
        }



        /// <summary>
        /// 
        /// </summary>
        public UserAuthentication UpdateUserName(UserName userName)
        {
            return new UserAuthentication
            {
                IsActive = IsActive,
                Password = Password,
                UserName = userName,
            };
        }



        /// <summary>
        /// 
        /// </summary>
        public UserAuthentication SetPassword(string password, IEncryptionService encryptionService)
        {
            return new UserAuthentication
            {
                IsActive = IsActive,
                Password = UserPassword.Create(password, encryptionService),
                UserName = UserName,
            };
        }


        /// <summary>
        /// 
        /// </summary>
        public UserAuthentication ChangePassword(string oldPassword, string newPassword, IEncryptionService encryptionService)
        {
            var isvalidOldPassword = Password.IsValidPassword(oldPassword, encryptionService);
            if (!isvalidOldPassword)
                throw new DomainException(DomainMessages.Incorrect_Old_Password);

            return SetPassword(newPassword, encryptionService);
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
        public UserAuthentication SetIsActive(bool isActive)
        {
            return new UserAuthentication
            {
                IsActive = UserIsActive.Create(isActive),
                Password = Password,
                UserName = UserName,
            };
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
            if (Password == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Password)));

            if (IsActive == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(IsActive)));

            if (UserName == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(UserName)));
        }


        #endregion
    }
}
