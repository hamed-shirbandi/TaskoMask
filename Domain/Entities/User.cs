using System;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Domain.Core.Services;

namespace TaskoMask.Domain.Entities
{
    public abstract class User : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public User(string displayName, string email, string userName, string password, IEncryptionService encryptionService)
        {
            DisplayName = displayName;
            Email = email;
            UserName = userName;
            ResetPassword(password, encryptionService);
        }



        #endregion

        #region Properties

        public string AvatarUrl { get; private set; }
        public string DisplayName { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public void Update(string displayName, string email, string userName)
        {
            DisplayName = displayName;
            Email = email;
            UserName = userName;
        }



        /// <summary>
        /// 
        /// </summary>
        public bool ValidatePassword(string password, IEncryptionService encryptionService)
        {
            var passwordHash = encryptionService.CreatePasswordHash(password, this.PasswordSalt);
            return passwordHash == this.PasswordHash;

        }



        /// <summary>
        /// 
        /// </summary>
        public void ResetPassword(string password, IEncryptionService encryptionService)
        {
            PasswordSalt = encryptionService.CreateSaltKey(5);
            PasswordHash = encryptionService.CreatePasswordHash(password, PasswordSalt);
        }



        /// <summary>
        /// 
        /// </summary>
        public void ChangePassword(string oldPassword, string newPassword, IEncryptionService encryptionService)
        {
            var isvalidOldPassword = ValidatePassword(oldPassword, encryptionService);
            if (isvalidOldPassword)
            {
                AddValidationError(DomainMessages.Incorrect_Password);
                return;
            }

            ResetPassword(newPassword, encryptionService);
        }

        #endregion

        #region Private Methods



        #endregion
    }
}
