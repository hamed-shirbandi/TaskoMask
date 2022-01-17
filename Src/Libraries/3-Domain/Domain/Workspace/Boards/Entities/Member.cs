
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Workspace.Boards.Entities
{
    /// <summary>
    /// Member of a board
    /// </summary>
    public class Member : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        public Member(string inviterOwnerId, string invitedOwnerId, string[] boardsId)
        {
            InviterOwnerId = inviterOwnerId;
            InvitedOwnerId = invitedOwnerId;
            BoardsId = boardsId;
        }



        #endregion

        #region Properties

        public string InvitedOwnerId { get; private set; }


        #endregion

        #region Public Methods



        #endregion

        #region Private Methods



        #endregion
    }
}
