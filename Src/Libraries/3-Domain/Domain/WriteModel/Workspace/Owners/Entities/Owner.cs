using System.Collections.Generic;
using System.Linq;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.ReadModel.Entities;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.Workspace.Organizations.Events;
using TaskoMask.Domain.Workspace.Organizations.Services;
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

        private Owner(string id, string displayName, string email)
        {
            if (string.IsNullOrEmpty(id))
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(id)));

            //shared key with User in authentication BC
            base.SetId(id);

            DisplayName = OwnerDisplayName.Create(displayName);
            Email = OwnerEmail.Create(email);

            CheckPolicies();

            AddDomainEvent(new OwnerCreatedEvent(Id, DisplayName.Value, Email.Value));
        }



        #endregion

        #region Properties

        public OwnerDisplayName DisplayName { get; private set; }
        public OwnerEmail Email { get; private set; }
        public ICollection<Organization> Organizations { get; set; }

        #endregion

        #region Public Owner Methods



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Shared key with User in authentication BC</param>
        /// <returns></returns>
        public static Owner CreateOwner(string id, string displayName, string email)
        {
            return new Owner(id, displayName, email);
        }



        ///// <summary>
        /////  
        ///// </summary>
        public void UpdateOwner(OwnerDisplayName displayName, OwnerEmail email)
        {
            DisplayName = displayName;
            Email = email;

            AddDomainEvent(new OwnerUpdatedEvent(Id, displayName.Value, email.Value));
        }




        /// <summary>
        /// 
        /// </summary>
        public void DeleteOwner()
        {
            base.Delete();
            AddDomainEvent(new OwnerDeletedEvent(Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void RecycleOwner()
        {
            base.Recycle();
            AddDomainEvent(new OwnerRecycledEvent(Id));
        }



        #endregion

        #region Public Organization Methods



        /// <summary>
        /// 
        /// </summary>
        public Organization CreateOrganization(string name, string description, string ownerOwnerId, IOrganizationValidatorService organizationValidatorService)
        {
            return Organization.CreateOrganization(name, description, ownerOwnerId, organizationValidatorService);
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateOrganization(string organizationId, string name, string description, IOrganizationValidatorService organizationValidatorService)
        {
            var organization = Organizations.FirstOrDefault(p => p.Id == organizationId);
            if (organization == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Organization));

            organization.UpdateOrganization(name, description, organizationValidatorService);

            base.UpdateModifiedDateTime();

            AddDomainEvent(new OrganizationUpdatedEvent(Id, organization.Name.Value, organization.Description.Value));
        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteOrganization(string organizationId)
        {
            var organization = Organizations.FirstOrDefault(p => p.Id == organizationId);
            if (organization == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Organization));

            organization.DeleteOrganization();
            AddDomainEvent(new OrganizationDeletedEvent(Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void RecycleOrganization(string organizationId)
        {
            var organization = Organizations.FirstOrDefault(p => p.Id == organizationId);
            if (organization == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Organization));

            organization.RecycleOrganization();
            AddDomainEvent(new OrganizationRecycledEvent(Id));
        }



        #endregion

        #region Public Project Methods



        /// <summary>
        /// 
        /// </summary>
        public void CreateProject(string organizationId, Project project)
        {
            var organization = Organizations.FirstOrDefault(p => p.Id == organizationId);
            if (organization == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Organization));

            organization.CreateProject(project);

            AddDomainEvent(new ProjectCreatedEvent(project.Id, project.Name.Value, project.Description.Value, Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateProject(string organizationId, string projectId, string name, string description)
        {
            var organization = Organizations.FirstOrDefault(p => p.Id == organizationId);
            if (organization == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Organization));

            organization.UpdateProject(projectId, name, description);

            var project = organization.Projects.FirstOrDefault(p => p.Id == projectId);

            AddDomainEvent(new ProjectUpdatedEvent(project.Id, project.Name.Value, project.Description.Value));
        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteProject(string organizationId, string projectId)
        {
            var organization = Organizations.FirstOrDefault(p => p.Id == organizationId);
            if (organization == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Organization));

            organization.DeleteProject(projectId);

            AddDomainEvent(new ProjectDeletedEvent(projectId));
        }



        /// <summary>
        /// 
        /// </summary>
        public void RecycleProject(string organizationId, string projectId)
        {
            var organization = Organizations.FirstOrDefault(p => p.Id == organizationId);
            if (organization == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Organization));
           
            organization.RecycleProject(projectId);

            AddDomainEvent(new ProjectRecycledEvent(projectId));
        }




        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies()
        {
            if (DisplayName == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(DisplayName)));

            if (Email == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Email)));

        }

        /// <summary>
        /// 
        /// </summary>
        protected override void CheckInvariants()
        {

        }


        #endregion
    }
}
