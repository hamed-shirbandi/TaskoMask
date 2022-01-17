using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Workspace.Owners.Events;
using TaskoMask.Domain.Workspace.Owners.ValueObjects;

namespace TaskoMask.Domain.Workspace.Owners.Entities
{
    /// <summary>
    /// Owners are those who manage their tasks in this system
    /// </summary>
    public class Owner : AggregateRoot
    {
        #region Fields


        #endregion

        #region Ctors

        private Owner(string id, OwnerDisplayName displayName, OwnerEmail email)
        {
            if (string.IsNullOrEmpty(id))
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(id)));

            //shared key with User in authentication BC
            base.SetId(id);

            DisplayName = displayName;
            Email = email;

            AddDomainEvent(new OwnerCreatedEvent(Id, displayName.Value, email.Value));
        }



        #endregion

        #region Properties

        public OwnerDisplayName DisplayName { get; private set; }
        public OwnerEmail Email { get; private set; }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Shared key with User in authentication BC</param>
        /// <returns></returns>
        public static Owner Create(string id, OwnerDisplayName displayName, OwnerEmail email)
        {
            return new Owner(id, displayName, email);
        }



        ///// <summary>
        /////  
        ///// </summary>
        public void Update(OwnerDisplayName displayName, OwnerEmail email)
        {
            DisplayName = displayName;
            Email = email;

            AddDomainEvent(new OwnerUpdatedEvent(Id, displayName.Value, email.Value));
        }




        /// <summary>
        /// 
        /// </summary>
        public override void Delete()
        {
            base.Delete();
            AddDomainEvent(new OwnerDeletedEvent(Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public override void Recycle()
        {
            base.Recycle();
            AddDomainEvent(new OwnerRecycledEvent(Id));
        }



        #endregion

        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        protected override void CheckInvariants()
        {
           
            if (DisplayName == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(DisplayName)));

            if (Email == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Email)));

        }


        #endregion
    }
}
