using TaskoMask.Domain.Core.Models;

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

        public Invitation(string inviterMemberId, string invitedMemberId)
        {
            InviterMemberId = inviterMemberId;
            InvitedMemberId = invitedMemberId;
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
