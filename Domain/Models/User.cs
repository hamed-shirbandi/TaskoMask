using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Models
{
    public class User : ApplicationUser
    {
        #region Properties


        public string DisplayName { get; private set; }


        #endregion


        #region Constructors


        public User(string displayName, string email, string userName)
        {
            DisplayName = displayName;
            Email = email;
            UserName = userName;
        }


        #endregion


        #region Main Methods


        public void SetDisplayName(string displayName)
        {
            DisplayName = displayName;
        }


        public void SetEmail(string email)
        {
            Email = email;
        }


        public void SetUserName(string userName)
        {
            UserName = userName;
        }


        #endregion
    }
}