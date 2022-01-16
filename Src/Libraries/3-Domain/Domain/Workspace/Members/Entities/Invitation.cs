using TaskoMask.Domain.Core.Models;
namespace TaskoMask.Domain.Workspace.Members.Entities
{
    /// <summary>
    /// To determine invited members to another member's account
    /// </summary>
    public class Invitation : AggregateRoot
    {
        #region Fields


        #endregion

        #region Ctors

        public Invitation(string inviterMemberId, string invitedMemberId, string[] boardsId)
        {
            InviterMemberId = inviterMemberId;
            InvitedMemberId = invitedMemberId;
            BoardsId = boardsId;
        }



        #endregion

        #region Properties

        public string InviterMemberId { get; private set; }
        public string InvitedMemberId { get; private set; }

        /// <summary>
        /// bords id to give access to invited member
        /// </summary>
        public string[] BoardsId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string OrganizationId { get; private set; }


        #endregion

        #region Public Methods



        #endregion

        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        protected override void CheckInvariants()
        {

        }



        #endregion
    }
}
