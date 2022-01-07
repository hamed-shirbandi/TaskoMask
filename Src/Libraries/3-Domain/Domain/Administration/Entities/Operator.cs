﻿using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Core.Services;
using TaskoMask.Domain.Core.ValueObjects;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.Administration.Entities
{
    /// <summary>
    /// opertors of admin panel
    /// </summary>
    public class Operator : BaseUser
    {
        #region Fields


        #endregion

        #region Ctors

        public Operator(UserIdentity identity, UserAuthentication authentication)
            : base(identity, authentication)
        {
        }



        #endregion

        #region Properties

        public string[] RolesId { get; set; }

        #endregion

        #region Public Methods


        ///// <summary>
        ///// 
        ///// </summary>
        public void Update(UserDisplayName displayName, UserEmail email, UserPhoneNumber phoneNumber, UserName userName)
        {
            UpdateIdentity(displayName, email, phoneNumber);
            UpdateAuthenticationUserName(userName);
            base.Update();

            CheckInvariants();
        }



        /// <summary>
        /// 
        /// </summary>
        public override void SetPassword(string password, IEncryptionService encryptionService)
        {
            base.SetPassword(password, encryptionService);
            CheckInvariants();
        }


        /// <summary>
        /// 
        /// </summary>
        public override void ChangePassword(string oldPassword, string newPassword, IEncryptionService encryptionService)
        {
            base.ChangePassword(oldPassword, newPassword, encryptionService);
            CheckInvariants();
        }
        


        /// <summary>
        /// 
        /// </summary>
        public override bool IsValidPassword(string password, IEncryptionService encryptionService)
        {
            return base.IsValidPassword(password, encryptionService);
            CheckInvariants();
        }




        /// <summary>
        /// 
        /// </summary>
        public override void SetIsActive(bool isActive)
        {
            base.SetIsActive(isActive);
            CheckInvariants();
        }



        /// <summary>
        /// 
        /// </summary>
        public override void SoftDelete()
        {
            base.SoftDelete();
            CheckInvariants();
        }



        /// <summary>
        /// 
        /// </summary>
        public override void Recycle()
        {
            base.Recycle();
            CheckInvariants();
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateRoles(string[] rolesId)
        {
            RolesId = rolesId;
            base.Update();
            CheckInvariants();
        }



        #endregion

        #region Private Methods

        protected override void CheckInvariants()
        {
            if (Identity.Email.Value.ToLower().Equals(Authentication.UserName.Value.ToLower()))
                throw new DomainException(DomainMessages.UserName_And_Email_Cannot_Be_The_Same);
        }



        #endregion
    }
}
