using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Team.Events;

namespace TaskoMask.Domain.Team.Entities
{
    /// <summary>
    /// To determine invited members to another member's account
    /// </summary>
    public class Invitation : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public Invitation(string displayName, string email,  string password)
        {

        }



        #endregion

        #region Properties

        public string InviterMemberId { get; private set; }
        public string InvitedMemberId { get; private set; }


        #endregion

        #region Public Methods



        #endregion

        #region Private Methods



        #endregion
    }
}
