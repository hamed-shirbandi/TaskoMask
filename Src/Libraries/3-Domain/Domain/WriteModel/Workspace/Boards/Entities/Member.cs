
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Enums;

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

        public Member(string memberOwnerId)
        {
            MemberOwnerId = memberOwnerId;
        }



        #endregion

        #region Properties

        /// <summary>
        /// Each member is an owner at the first
        /// This is a foreign key to Owner
        /// </summary>
        public string MemberOwnerId { get; private set; }
        public BoardMemberAccessLevel AccessLevel { get; private set; }


        #endregion

        #region Public Methods



        #endregion

        #region Private Methods



        #endregion
    }
}
