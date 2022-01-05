using TaskoMask.Domain.Core.ValueObjects;

namespace TaskoMask.Domain.Core.Models
{
    public abstract  class BaseUser :BaseAggregate
    {
        #region Ctors

        public BaseUser(UserIdentity identity, UserAuthentication authentication)
        {
            Identity = identity;
            Authentication = authentication;
        }


        #endregion

        #region Properties


        public UserIdentity Identity { get; private set; }
        public UserAuthentication Authentication { get; private set; }

        #endregion

        #region Public Methods




        #endregion

        #region Protected Methods



        /// <summary>
        /// 
        /// </summary>
        protected void Update(UserIdentity identity, UserAuthentication authentication)
        {
            Identity = identity;
            Authentication = authentication;

            base.Update();
        }



        #endregion

        #region Private Methods


        #endregion
    }
}
