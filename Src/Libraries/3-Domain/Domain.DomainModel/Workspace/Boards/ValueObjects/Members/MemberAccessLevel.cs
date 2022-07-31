using System;
using System.Collections.Generic;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Enums;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.DomainModel.Workspace.Boards.ValueObjects.Members
{
    public class MemberAccessLevel : BaseValueObject
    {
        #region Properties

        public BoardMemberAccessLevel Value { get; private set; }


        #endregion

        #region Ctors

        public MemberAccessLevel(BoardMemberAccessLevel value)
        {
            Value = value;

            CheckPolicies();
        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static MemberAccessLevel Create(BoardMemberAccessLevel value)
        {
            return new MemberAccessLevel(value);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
           
        }



        /// <summary>
        /// 
        /// </summary>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }


        #endregion

    }
}
