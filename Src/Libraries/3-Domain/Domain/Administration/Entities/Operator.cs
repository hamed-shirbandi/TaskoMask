using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.ValueObjects;

namespace TaskoMask.Domain.Administration.Entities
{
    /// <summary>
    /// opertors of admin panel
    /// </summary>
   public class Operator : BaseUser
    {
        #region Fields


        #endregion

        #region Ctors

        public Operator(UserIdentity identity, UserAuthentication authentication)
            :base(identity, authentication)
        {
        }



        #endregion

        #region Properties

        public string[] RolesId { get; set; }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public void Update(string displayName, string email, string userName)
        {
            base.Update();
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

        protected override void CheckInvariants()
        {
            throw new System.NotImplementedException();
        }



        #endregion
    }
}
