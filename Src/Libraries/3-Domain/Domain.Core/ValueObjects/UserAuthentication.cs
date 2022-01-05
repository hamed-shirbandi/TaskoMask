using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;
using System.Collections.Generic;

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

        protected UserAuthentication(UserName userName, UserPassword Password, IEncryptionService encryptionService)
        {
            UserName = userName;
            //ResetPassword(password, encryptionService);
            IsActive = UserIsActive.Create(true);
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
        public virtual bool ValidatePassword(string password, IEncryptionService encryptionService)
        {
            var passwordHash = encryptionService.CreatePasswordHash(password, this.Password.PasswordSalt);
            return passwordHash == this.Password.PasswordHash;

        }



        /// <summary>
        /// 
        /// </summary>
        public virtual void ResetPassword(string password, IEncryptionService encryptionService)
        {
            //PasswordSalt = encryptionService.CreateSaltKey(5);
            //PasswordHash = encryptionService.CreatePasswordHash(password, PasswordSalt);
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual void ChangePassword(string oldPassword, string newPassword, IEncryptionService encryptionService)
        {
            var isvalidOldPassword = ValidatePassword(oldPassword, encryptionService);
            if (isvalidOldPassword)
            {
              //  AddValidationError(DomainMessages.Incorrect_Password);
                return;
            }

            ResetPassword(newPassword, encryptionService);
        }



        /// <summary>
        /// 
        /// </summary>
        public void SetActive(bool isActive)
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
            
        }


        #endregion
    }
}
