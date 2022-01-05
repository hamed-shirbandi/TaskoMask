using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Core.ValueObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class UserIdentity : BaseValueObject
    {
        #region Properties

        public UserDisplayName DisplayName { get; private set; }
        public UserEmail Email { get; private set; }
        public UserPhoneNumber PhoneNumber { get; private set; }

        #endregion

        #region Ctors

        private UserIdentity(UserDisplayName displayName, UserEmail email, UserPhoneNumber phoneNumber)
        {
            DisplayName = displayName;
            Email = email;
            PhoneNumber = phoneNumber;

            CheckPolicies();
        }



        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static UserIdentity Create(UserDisplayName displayName, UserEmail email, UserPhoneNumber phoneNumber)
        {
            return new UserIdentity(displayName, email, phoneNumber);
        }






        /// <summary>
        /// 
        /// </summary>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DisplayName;
            yield return Email;
            yield return PhoneNumber;
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
