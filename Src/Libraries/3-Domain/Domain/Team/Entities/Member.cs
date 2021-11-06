using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Team.Events;

namespace TaskoMask.Domain.Team.Entities
{
    /// <summary>
    /// Members are those who manage their tasks in this system
    /// </summary>
    public class Member : User
    {
        #region Fields


        #endregion

        #region Ctors

        public Member(string displayName, string email,  string password, IEncryptionService encryptionService)
        :base(displayName,"", email, email, password,encryptionService)
        {
            AddDomainEvent(new MemberCreatedEvent(Id,DisplayName,Email,UserName));
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
