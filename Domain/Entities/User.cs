using System.ComponentModel.DataAnnotations;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Domain.Entities
{
    [Display(Name = nameof(DomainMetadata.User), ResourceType = typeof(DomainMetadata))]
    public class User : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public User(string displayName, string email, string userName)
        {
            DisplayName = displayName;
            Email = email;
            UserName = userName;
        }

        #endregion

        #region Properties

        public string AvatarUrl { get; private set; }
        public string DisplayName { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        

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



        #endregion

        #region Private Methods



        #endregion
    }
}
