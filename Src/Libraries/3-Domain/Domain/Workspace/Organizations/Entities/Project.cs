using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Workspace.Organizations.ValueObjects;
using TaskoMask.Domain.Workspace.Organizations.Events;

namespace TaskoMask.Domain.Workspace.Organizations.Entities
{
    public class Project : BaseAggregate
    {
        #region Fields


        #endregion

        #region Ctors

        private Project(ProjectName name, ProjectDescription description, ProjectOrganizationId organizationId)
        {
            Name = name;
            Description = description;
            OrganizationId = organizationId;

            AddDomainEvent(new ProjectCreatedEvent(Id, name.Value, Description.Value, OrganizationId.Value));
        }


        #endregion

        #region Properties

        public ProjectName Name { get; private set; }
        public ProjectDescription Description { get; private set; }
        public ProjectOrganizationId OrganizationId { get; private set; }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public static Project Create(ProjectName name, ProjectDescription description, ProjectOrganizationId organizationId)
        {
            return new Project(name, description, organizationId);
        }



        /// <summary>
        /// 
        /// </summary>
        public void Update(ProjectName name, ProjectDescription description, ProjectOrganizationId organizationId)
        {
            Description = description;
            Name = name;
            OrganizationId = organizationId;
            base.Update();

            AddDomainEvent(new ProjectUpdatedEvent(Id, Name.Value, Description.Value,OrganizationId.Value));
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

            if (OrganizationId == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(OrganizationId)));

            if (Name.Value.Equals(Description.Value))
                throw new DomainException(DomainMessages.Equal_Name_And_Description_Error);

        }

        #endregion

    }
}
