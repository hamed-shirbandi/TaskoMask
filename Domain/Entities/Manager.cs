using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Events;

namespace TaskoMask.Domain.Entities
{
    /// <summary>
    /// Managers are those who manage their tasks in this system
    /// </summary>
    public class Manager : User
    {
        #region Fields


        #endregion

        #region Ctors

        public Manager(string displayName, string email,  string password, IEncryptionService encryptionService)
        :base(displayName, email, email, password,encryptionService)
        {
            AddDomainEvent(new ManagerCreatedEvent(Id,DisplayName,Email,UserName));
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
