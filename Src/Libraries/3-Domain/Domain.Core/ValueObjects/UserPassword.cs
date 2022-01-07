using System.Collections.Generic;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.Core.ValueObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class UserPassword : BaseValueObject
    {
        #region Properties

        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set; }

        #endregion

        #region Ctors



        /// <summary>
        /// 
        /// </summary>
        private UserPassword(string password, IEncryptionService encryptionService)
        {
            CheckPasswordPolicies(password);

            PasswordSalt = encryptionService.CreateSaltKey(5);
            PasswordHash = encryptionService.CreatePasswordHash(password, PasswordSalt);

            CheckPolicies();
        }


        /// <summary>
        /// 
        /// </summary>
        private UserPassword()
        {

        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static UserPassword Create(string password, IEncryptionService encryptionService)
        {
            return new UserPassword(password, encryptionService);
        }


        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static UserPassword CreateDefault()
        {
            return new UserPassword
            {
                PasswordHash = "",
                PasswordSalt = ""
            };
        }



        /// <summary>
        /// 
        /// </summary>
        public bool IsValidPassword(string password, IEncryptionService encryptionService)
        {
            var passwordHash = encryptionService.CreatePasswordHash(password, PasswordSalt);
            return passwordHash == this.PasswordHash;
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(PasswordHash))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(PasswordHash)));

            if (string.IsNullOrEmpty(PasswordSalt))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(PasswordSalt)));
        }



        /// <summary>
        /// 
        /// </summary>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PasswordHash;
            yield return PasswordSalt;
        }



        /// <summary>
        /// 
        /// </summary>
        private void CheckPasswordPolicies(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new DomainException(string.Format(DomainMessages.Required, nameof(password)));

            if (password.Length < 4)
                throw new DomainException(string.Format(DomainMessages.Min_Length_Error, nameof(password)));

        }


        #endregion

    }
}
