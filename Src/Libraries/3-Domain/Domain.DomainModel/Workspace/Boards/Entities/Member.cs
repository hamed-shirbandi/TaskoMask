
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.DomainModel.Workspace.Boards.ValueObjects.Members;

namespace TaskoMask.Domain.DomainModel.Workspace.Boards.Entities
{
    /// <summary>
    /// Member of a board
    /// </summary>
    public class Member : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        private Member(string ownerId, BoardMemberAccessLevel accessLevel)
        {
            OwnerId = MemberOwnerId.Create(ownerId);
            AccessLevel = MemberAccessLevel.Create(accessLevel);

            CheckPolicies();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Each member is an owner at the first
        /// This is a foreign key to Owner
        /// </summary>
        public MemberOwnerId OwnerId { get; private set; }

        public MemberAccessLevel AccessLevel { get; private set; }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public static Member Create(string ownerId, BoardMemberAccessLevel accessLevel)
        {
            return new Member(ownerId, accessLevel);
        }




        /// <summary>
        /// 
        /// </summary>
        public void Update(BoardMemberAccessLevel accessLevel)
        {
            AccessLevel = MemberAccessLevel.Create(accessLevel);
            base.UpdateModifiedDateTime();

            CheckPolicies();
        }



        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies()
        {
            if (OwnerId == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(OwnerId)));

            if (AccessLevel == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(AccessLevel)));

        }


        #endregion
    }

}
