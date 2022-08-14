using System.Collections.Generic;
using System.Linq;
using TaskoMask.Services.Monolith.Domain.Core.Exceptions;
using TaskoMask.Services.Monolith.Domain.Core.Models;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Monolith.Domain.Core.Services;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Events.Organizations;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Events.Owners;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Events.Projects;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Specifications;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.ValueObjects.Owners;
using TaskoMask.Services.Monolith.Domain.Core.Resources;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities
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
          
            //shared key with User in authentication BC
            base.SetId(id);

            DisplayName = OwnerDisplayName.Create(displayName);
            Email = OwnerEmail.Create(email);
            Organizations = new HashSet<Organization>();

            CheckPolicies();

            AddDomainEvent(new OwnerRegisteredEvent(Id, DisplayName.Value, Email.Value));
        }



        #endregion

        #region Properties

        public OwnerDisplayName DisplayName { get; private set; }
        public OwnerEmail Email { get; private set; }
        public ICollection<Organization> Organizations { get; private set; }

        #endregion

        #region Public Owner Methods



        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Shared key with User in authentication BC</param>
        /// <returns></returns>
        public static Owner RegisterOwner(string id, string displayName, string email)
        {
            return new Owner(id, displayName, email);
        }



        ///// <summary>
        /////  
        ///// </summary>
        public void UpdateOwnerProfile(OwnerDisplayName displayName, OwnerEmail email)
        {
            DisplayName = displayName;
            Email = email;

            AddDomainEvent(new OwnerProfileUpdatedEvent(Id, displayName.Value, email.Value));
        }





        #endregion

        #region Public Organization Methods



        /// <summary>
        /// 
        /// </summary>
        public void AddOrganization(Organization organization)
        {
            Organizations.Add(organization);
            AddDomainEvent(new OrganizationAddedEvent(organization.Id, organization.Name.Value, organization.Description.Value,this.Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateOrganization(string organizationId, string name, string description, IAuthenticatedUserService authenticatedUserService)
        {
            if (!new JustOwnerCanUpdateOrganizationSpecification(authenticatedUserService).IsSatisfiedBy(this))
                throw new DomainException(ContractsMessages.Access_Denied);

            var organization = GetOrganizationById(organizationId);
            organization.UpdateOrganization(name, description);
            AddDomainEvent(new OrganizationUpdatedEvent(organizationId, organization.Name.Value, organization.Description.Value));
        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteOrganization(string organizationId, IAuthenticatedUserService authenticatedUserService)
        {
            if (!new JustOwnerCanUpdateOrganizationSpecification(authenticatedUserService).IsSatisfiedBy(this))
                throw new DomainException(ContractsMessages.Access_Denied);

            var organization = GetOrganizationById(organizationId);
            Organizations.Remove(organization);
            AddDomainEvent(new OrganizationDeletedEvent(organizationId));
        }




        #endregion

        #region Public Project Methods



        /// <summary>
        /// 
        /// </summary>
        public void AddProject(string organizationId, Project project)
        {
            var organization = GetOrganizationById(organizationId);
            
            organization.AddProject(project);

            AddDomainEvent(new ProjectAddedEvent(project.Id, project.Name.Value, project.Description.Value, organization.Id,Id));
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateProject(string projectId, string name, string description)
        {
            var organization = GetOrganizationByProjectId(projectId);

            organization.UpdateProject(projectId, name, description);

            var project = organization.Projects.FirstOrDefault(p => p.Id == projectId);

            AddDomainEvent(new ProjectUpdatedEvent(project.Id, project.Name.Value, project.Description.Value));
        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteProject(string projectId)
        {
            var organization = GetOrganizationByProjectId(projectId);
          
            organization.DeleteProject(projectId);

            AddDomainEvent(new ProjectDeletedEvent(projectId));
        }


        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Id))
                throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(Id)));

            if (DisplayName == null)
                throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(DisplayName)));

            if (Email == null)
                throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(Email)));
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckInvariants()
        {
            if (!new OwnerMaxOrganizationsSpecification().IsSatisfiedBy(this))
                throw new DomainException(string.Format(DomainMessages.Max_Organizations_Count_Limitiation, DomainConstValues.Owner_Max_Organizations_Count));

            if (!new OrganizationNameMustUniqueSpecification().IsSatisfiedBy(this))
                throw new DomainException(string.Format(DomainMessages.Name_Already_Exist, DomainMetadata.Organization));

            if (!new OrganizationMaxProjectsSpecification().IsSatisfiedBy(this))
                throw new DomainException(string.Format(DomainMessages.Max_Projects_Count_Limitiation, DomainConstValues.Organization_Max_Projects_Count));

            if (!new ProjectNameMustUniqueSpecification().IsSatisfiedBy(this))
                throw new DomainException(string.Format(DomainMessages.Name_Already_Exist, DomainMetadata.Project));
        }



        /// <summary>
        /// 
        /// </summary>
        private Organization GetOrganizationByProjectId(string projectId)
        {
            var organization = Organizations.FirstOrDefault(p => p.Projects.Any(p => p.Id == projectId));
            if (organization == null)
                throw new DomainException(string.Format(ContractsMessages.Not_Found, DomainMetadata.Organization));

            return organization;
        }



        /// <summary>
        /// 
        /// </summary>
        private Organization GetOrganizationById(string organizationId)
        {
            var organization = Organizations.FirstOrDefault(p => p.Id == organizationId);
            if (organization == null)
                throw new DomainException(string.Format(ContractsMessages.Not_Found, DomainMetadata.Organization));
            return organization;
        }

        #endregion
    }
}
