using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.ValueObjects;

namespace TaskoMask.Domain.Administration.Entities
{
    /// <summary>
    /// opertors of admin panel
    /// </summary>
   public class Operator :BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public Operator(string displayName,string phoneNumber, string email )
        {
        }



        #endregion

        #region Properties

        
        public UserAuthentication Authentication { get; private set; }


        public string[] RolesId { get; set; }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public override void Update(string displayName, string email, string userName)
        {
            base.Update(displayName,email, userName);
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateRoles(string[] rolesId)
        {
            RolesId = rolesId;
            base.Update();
        }



        #endregion

        #region Private Methods



        #endregion
    }
}
