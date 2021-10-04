using TaskoMask.Domain.Administration.Events;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;


namespace TaskoMask.Domain.Administration.Entities
{
    /// <summary>
    /// opertors of admin panel
    /// </summary>
   public class Operator :BaseUser
    {
        #region Fields


        #endregion

        #region Ctors

        public Operator(string displayName, string email, string userName, string password, IEncryptionService encryptionService)
        :base(displayName, email, userName, password,encryptionService)
        {
            AddDomainEvent(new OperatorCreatedEvent(Id,DisplayName,Email,UserName));

        }



        #endregion

        #region Properties



        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public override void Update(string displayName, string email, string userName)
        {
            base.Update(displayName,email, userName);
        }


        #endregion

        #region Private Methods



        #endregion
    }
}
