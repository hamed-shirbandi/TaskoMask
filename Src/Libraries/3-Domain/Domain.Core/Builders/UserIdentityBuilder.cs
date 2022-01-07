using TaskoMask.Domain.Core.ValueObjects;

namespace TaskoMask.Domain.Core.Builders
{
    public class UserIdentityBuilder
    {

        #region Properties

        public UserDisplayName DisplayName { get; private set; }
        public UserEmail Email { get; private set; }
        public UserPhoneNumber PhoneNumber { get; private set; }

        #endregion

        #region Ctors



        /// <summary>
        /// 
        /// </summary>
        private UserIdentityBuilder()
        {
        }



        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public static UserIdentityBuilder Init()
        {
            return new UserIdentityBuilder();
        }



        /// <summary>
        /// 
        /// </summary>
        public UserIdentityBuilder WithDisplayName(string displayName)
        {
            DisplayName = UserDisplayName.Create(displayName);
            return this;
        }



        /// <summary>
        /// 
        /// </summary>
        public UserIdentityBuilder WithEmail(string email)
        {
            Email = UserEmail.Create(email);
            return this;
        }



        /// <summary>
        /// 
        /// </summary>
        public UserIdentityBuilder WithPhoneNumber(string phoneNumber)
        {
            PhoneNumber = UserPhoneNumber.Create(phoneNumber);
            return this;
        }



        /// <summary>
        /// 
        /// </summary>
        public UserIdentity Build() => UserIdentity.Create(DisplayName,Email,PhoneNumber);


        #endregion


    }
}
