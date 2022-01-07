using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Team.Entities.Organizations.ValueObjects;
using TaskoMask.Domain.Team.Members.Events;

namespace TaskoMask.Domain.Team.Entities
{
    public class Organization : BaseAggregate
    {
        #region Fields


        #endregion

        #region Ctors

        private Organization(OrganizationName name, OrganizationDescription description, OrganizationOwnerMemberId ownerMemberId)
        {
            Name = name;
            Description = description;
            OwnerMemberId = ownerMemberId;

            AddDomainEvent(new OrganizationCreatedEvent(Id, Name.Value, Description.Value, OwnerMemberId.Value));
        }


        #endregion

        #region Properties

        public OrganizationName Name { get; private set; }
        public OrganizationDescription Description { get; private set; }
        public OrganizationOwnerMemberId OwnerMemberId { get; private set; }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public static Organization Create(OrganizationName name, OrganizationDescription description, OrganizationOwnerMemberId ownerMemberId)
        {
            return new Organization(name,description,ownerMemberId);
        }
  


        /// <summary>
        /// 
        /// </summary>
        public void Update(OrganizationName name, OrganizationDescription description)
        {
            Description = description;
            Name = name;
            base.Update();

            AddDomainEvent(new OrganizationUpdatedEvent(Id, Name.Value, Description.Value));
        }



        #endregion

        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        protected override void CheckInvariants()
        {
            if (Name == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Name)));

            if (Description == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Description)));

            if (OwnerMemberId == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(OwnerMemberId)));

            if (Name.Value.Equals(Description.Value))
                AddValidationError(DomainMessages.Equal_Name_And_Description_Error);
        }

        #endregion

    }
}
