using TaskoMask.Domain.Core.Models;
namespace TaskoMask.Domain.Workspace.Owners.Entities
{
    /// <summary>
    /// To determine invited owners to another owner's account
    /// </summary>
    public class Invitation : AggregateRoot
    {
        #region Fields


        #endregion

        #region Ctors

        public Invitation(string inviterOwnerId, string invitedOwnerId, string[] boardsId)
        {
            InviterOwnerId = inviterOwnerId;
            InvitedOwnerId = invitedOwnerId;
            BoardsId = boardsId;
        }



        #endregion

        #region Properties

        public string InviterOwnerId { get; private set; }
        public string InvitedOwnerId { get; private set; }

        /// <summary>
        /// bords id to give access to invited owner
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
