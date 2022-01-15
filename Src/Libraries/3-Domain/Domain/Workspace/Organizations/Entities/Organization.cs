using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Workspace.Organizations.ValueObjects;
using TaskoMask.Domain.Workspace.Organizations.Events;
using TaskoMask.Domain.Workspace.Organizations.Specifications;
using TaskoMask.Domain.Workspace.Organizations.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskoMask.Domain.Workspace.Organizations.Entities
{
    public class Organization : BaseAggregate
    {
        #region Fields


        #endregion

        #region Ctors

        private Organization(OrganizationName name, OrganizationDescription description, OrganizationOwnerMemberId ownerMemberId, IOrganizationValidatorService organizationValidatorService)
        {
            Name = name;
            Description = description;
            OwnerMemberId = ownerMemberId;

            CheckPolicies(organizationValidatorService);

            AddDomainEvent(new OrganizationCreatedEvent(Id, Name.Value, Description.Value, OwnerMemberId.Value));
        }



        #endregion

        #region Properties

        public OrganizationName Name { get; private set; }
        public OrganizationDescription Description { get; private set; }
        public OrganizationOwnerMemberId OwnerMemberId { get; private set; }

        public ICollection<Project> Projects { get; set; }

        #endregion

        #region Public Organization Methods



        /// <summary>
        /// 
        /// </summary>
        public static Organization CreateOrganization(OrganizationName name, OrganizationDescription description, OrganizationOwnerMemberId ownerMemberId, IOrganizationValidatorService organizationValidatorService)
        {
            return new Organization(name, description, ownerMemberId, organizationValidatorService);
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateOrganization(string name, string description, IOrganizationValidatorService organizationValidatorService)
        {
            Name = OrganizationName.Create(name);
            Description = OrganizationDescription.Create(name);

            base.UpdateModifiedDateTime();

            CheckPolicies(organizationValidatorService);

            AddDomainEvent(new OrganizationUpdatedEvent(Id, Name.Value, Description.Value));
        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteOrganization()
        {
            base.Delete();
            AddDomainEvent(new OrganizationDeletedEvent(Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void RecycleOrganization()
        {
            base.Recycle();
            AddDomainEvent(new OrganizationRecycledEvent(Id));
        }



        #endregion

        #region Public Project Methods



        /// <summary>
        /// 
        /// </summary>
        public void CreateProject(ProjectName name, ProjectDescription description )
        {
            var project=  Project.Create(name, description,ProjectOrganizationId.Create(Id));
            Projects.Add(project);
            AddDomainEvent(new ProjectCreatedEvent(project.Id, name.Value, Description.Value,Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateProject(string id, ProjectName name, ProjectDescription description)
        {
            var project = Projects.FirstOrDefault(p=>p.Id== id);
            if (project ==null)
                throw new DomainException(string.Format(DomainMessages.Not_Found,DomainMetadata.Project));

            project.Update(name, description);

            AddDomainEvent(new ProjectUpdatedEvent(Id, Name.Value, Description.Value));
        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteProject(string id)
        {
            var project = Projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Project));

            project.Delete();
            AddDomainEvent(new ProjectDeletedEvent(Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void RecycleProject(string id)
        {
            var project = Projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Project));

            project.Recycle();
            AddDomainEvent(new ProjectRecycledEvent(Id));
        }




        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies(IOrganizationValidatorService organizationValidatorService)
        {
            if (Name == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Name)));

            if (Description == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Description)));

            if (OwnerMemberId == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(OwnerMemberId)));

            if (!new OrganizationNameMustUniqueSpecification(organizationValidatorService).IsSatisfiedBy(this))
                throw new DomainException(string.Format(DomainMessages.Name_Already_Exist, DomainMetadata.Organization));
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckInvariants()
        {
            if (!new OrganizationNameAndDescriptionCannotSameSpecification().IsSatisfiedBy(this))
                throw new DomainException(DomainMessages.Equal_Name_And_Description_Error);
        }



        #endregion

    }
}
