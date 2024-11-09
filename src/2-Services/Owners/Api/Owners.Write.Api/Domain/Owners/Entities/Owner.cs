using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Entities;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Events.Organizations;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Events.Owners;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Events.Projects;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Services;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Specifications;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.ValueObjects.Owners;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Entities;

/// <summary>
/// Owners are those who manage their tasks in this system
/// </summary>
public class Owner : AggregateRoot
{
    #region Fields


    #endregion

    #region Ctors

    private Owner(string displayName, string email, IOwnerValidatorService ownerValidatorService)
    {
        SetId(ObjectId.GenerateNewId().ToString());

        DisplayName = OwnerDisplayName.Create(displayName);
        Email = OwnerEmail.Create(email);
        Organizations = new HashSet<Organization>();

        CheckPolicies(ownerValidatorService);

        AddDomainEvent(new OwnerRegisteredEvent(Id, DisplayName.Value, Email.Value));
    }

    #endregion

    #region Properties

    public OwnerDisplayName DisplayName { get; private set; }
    public OwnerEmail Email { get; private set; }
    public ICollection<Organization> Organizations { get; private set; }

    #endregion

    #region Owner Behaviors



    /// <summary>
    ///
    /// </summary>
    public static Owner RegisterOwner(string displayName, string email, IOwnerValidatorService ownerValidatorService)
    {
        return new Owner(displayName, email, ownerValidatorService);
    }

    ///// <summary>
    /////
    ///// </summary>
    public void UpdateOwnerProfile(OwnerDisplayName displayName, OwnerEmail email, IOwnerValidatorService ownerValidatorService)
    {
        DisplayName = displayName;
        Email = email;

        CheckPolicies(ownerValidatorService);

        AddDomainEvent(new OwnerProfileUpdatedEvent(Id, displayName.Value, email.Value));
    }

    #endregion

    #region Organization Behaviors



    /// <summary>
    ///
    /// </summary>
    public void AddOrganization(Organization organization)
    {
        Organizations.Add(organization);
        AddDomainEvent(new OrganizationAddedEvent(organization.Id, organization.Name.Value, organization.Description.Value, Id));
    }

    /// <summary>
    ///
    /// </summary>
    public void UpdateOrganization(string organizationId, string name, string description)
    {
        var organization = GetOrganizationById(organizationId);
        organization.UpdateOrganization(name, description);
        AddDomainEvent(new OrganizationUpdatedEvent(organizationId, organization.Name.Value, organization.Description.Value));
    }

    /// <summary>
    ///
    /// </summary>
    public void DeleteOrganization(string organizationId)
    {
        var organization = GetOrganizationById(organizationId);
        Organizations.Remove(organization);
        AddDomainEvent(new OrganizationDeletedEvent(organizationId));
    }

    /// <summary>
    ///
    /// </summary>
    public Organization GetOrganizationById(string organizationId)
    {
        var organization = Organizations.FirstOrDefault(p => p.Id == organizationId);
        if (organization == null)
            throw new DomainException(string.Format(ContractsMessages.Not_Found, DomainMetadata.Organization));
        return organization;
    }

    #endregion

    #region Project Behaviors



    /// <summary>
    ///
    /// </summary>
    public void AddProject(string organizationId, Project project)
    {
        var organization = GetOrganizationById(organizationId);

        organization.AddProject(project);

        AddDomainEvent(new ProjectAddedEvent(project.Id, project.Name.Value, project.Description.Value, organization.Id, Id));
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

    /// <summary>
    ///
    /// </summary>
    public Project GetProjectById(string projectId)
    {
        var organization = GetOrganizationByProjectId(projectId);

        return organization.GetProjectById(projectId);
    }

    #endregion

    #region Methods



    /// <summary>
    ///
    /// </summary>
    private void CheckPolicies(IOwnerValidatorService ownerValidatorService)
    {
        if (string.IsNullOrEmpty(Id))
            throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(Id)));

        if (DisplayName == null)
            throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(DisplayName)));

        if (Email == null)
            throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(Email)));

        if (!new OwnerEmailMustUniqueSpecification(ownerValidatorService).IsSatisfiedBy(this))
            throw new DomainException(DomainMessages.Email_Already_Exist);
    }

    /// <summary>
    ///
    /// </summary>
    protected override void CheckInvariants()
    {
        if (!new OwnerMaxOrganizationsSpecification().IsSatisfiedBy(this))
        {
            throw new DomainException(
                string.Format(DomainMessages.Max_Organizations_Count_Limitiation, DomainConstValues.OWNER_MAX_ORGANIZATIONS_COUNT)
            );
        }

        if (!new OrganizationNameMustUniqueSpecification().IsSatisfiedBy(this))
            throw new DomainException(string.Format(DomainMessages.Name_Already_Exist, DomainMetadata.Organization));

        if (!new OrganizationMaxProjectsSpecification().IsSatisfiedBy(this))
        {
            throw new DomainException(
                string.Format(DomainMessages.Max_Projects_Count_Limitiation, DomainConstValues.ORGANIZATION_MAX_PROJECTS_COUNT)
            );
        }

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
            throw new DomainException(string.Format(ContractsMessages.Not_Found, DomainMetadata.Project));

        return organization;
    }

    #endregion
}
