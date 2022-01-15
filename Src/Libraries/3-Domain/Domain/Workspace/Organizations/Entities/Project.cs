using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Workspace.Organizations.Specifications;
using TaskoMask.Domain.Workspace.Organizations.ValueObjects;

namespace TaskoMask.Domain.Workspace.Organizations.Entities
{
    public class Project : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        private Project(ProjectName name, ProjectDescription description, ProjectOrganizationId organizationId)
        {
            Name = name;
            Description = description;
            OrganizationId = organizationId;

            CheckPolicies();
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
        public void Update(ProjectName name, ProjectDescription description )
        {
            Description = description;
            Name = name;
            base.UpdateModifiedDateTime();

            CheckPolicies();
        }



        /// <summary>
        /// 
        /// </summary>
        public override void Delete()
        {
            base.Delete();
            base.UpdateModifiedDateTime();
        }



        /// <summary>
        /// 
        /// </summary>
        public override void Recycle()
        {
            base.Recycle();
            base.UpdateModifiedDateTime();
        }



        #endregion

        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies()
        {
            if (Name == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Name)));

            if (Description == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Description)));

            if (OrganizationId == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(OrganizationId)));

            if (!new ProjectNameAndDescriptionCannotSameSpecification().IsSatisfiedBy(this))
                throw new DomainException(DomainMessages.Equal_Name_And_Description_Error);

        }


        #endregion

    }
}
