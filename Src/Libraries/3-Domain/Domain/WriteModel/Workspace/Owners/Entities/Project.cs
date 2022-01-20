using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Specifications;
using TaskoMask.Domain.WriteModel.Workspace.Owners.ValueObjects.Projects;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Entities
{
    public class Project : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        private Project(string name, string description, string organizationId)
        {
            Name = ProjectName.Create(name);
            Description = ProjectDescription.Create(description) ;
            OrganizationId = ProjectOrganizationId.Create(organizationId);

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
        public static Project Create(string name, string description, string organizationId)
        {
            return new Project(name, description, organizationId);
        }



        /// <summary>
        /// 
        /// </summary>
        public void Update(string name, string description )
        {
            Description = ProjectDescription.Create(description);
            Name = ProjectName.Create(name);
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
