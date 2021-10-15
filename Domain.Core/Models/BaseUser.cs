using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Resources;
using TaskoMask.Domain.Core.Services;

namespace TaskoMask.Domain.Core.Models
{
    /// <summary>
    /// base class for users
    /// </summary>
    public abstract class BaseUser : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        protected BaseUser(string displayName, string email, string userName, string password, IEncryptionService encryptionService)
        {
            DisplayName = displayName;
            Email = email;
            UserName = userName;
            ResetPassword(password, encryptionService);
            IsActive = true;
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
        public bool IsActive { get; set; }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public virtual void Update(string displayName, string email, string userName)
        {
            DisplayName = displayName;
            Email = email;
            UserName = userName;
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual bool ValidatePassword(string password, IEncryptionService encryptionService)
        {
            var passwordHash = encryptionService.CreatePasswordHash(password, this.PasswordSalt);
            return passwordHash == this.PasswordHash;

        }



        /// <summary>
        /// 
        /// </summary>
        public virtual void ResetPassword(string password, IEncryptionService encryptionService)
        {
            PasswordSalt = encryptionService.CreateSaltKey(5);
            PasswordHash = encryptionService.CreatePasswordHash(password, PasswordSalt);
        }



        /// <summary>
        /// 
        /// </summary>
        public virtual void ChangePassword(string oldPassword, string newPassword, IEncryptionService encryptionService)
        {
            var isvalidOldPassword = ValidatePassword(oldPassword, encryptionService);
            if (isvalidOldPassword)
            {
                AddValidationError(DomainMessages.Incorrect_Password);
                return;
            }

            ResetPassword(newPassword, encryptionService);
        }



        /// <summary>
        /// 
        /// </summary>
        public void SetActive(bool isActive)
        {
            IsActive = isActive;
        }

        #endregion

        #region Private Methods



        #endregion
    }
}
