using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.BuildingBlocks.Domain.Entities;
using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Resources;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.Specifications;
using TaskoMask.Services.Owners.Write.Api.Domain.Owners.ValueObjects.Organizations;

namespace TaskoMask.Services.Owners.Write.Api.Domain.Owners.Entities;

public class Organization : BaseEntity
{
    #region Fields


    #endregion

    #region Ctors

    private Organization(string name, string description)
    {
        SetId(ObjectId.GenerateNewId().ToString());

        Name = OrganizationName.Create(name);
        Description = OrganizationDescription.Create(description);
        Projects = new HashSet<Project>();
        CheckPolicies();
    }

    #endregion

    #region Properties

    public OrganizationName Name { get; private set; }
    public OrganizationDescription Description { get; private set; }
    public ICollection<Project> Projects { get; private set; }

    #endregion

    #region Organization Behaviors



    /// <summary>
    ///
    /// </summary>
    public static Organization CreateOrganization(string name, string description)
    {
        return new Organization(name, description);
    }

    /// <summary>
    ///
    /// </summary>
    public void UpdateOrganization(string name, string description)
    {
        Name = OrganizationName.Create(name);
        Description = OrganizationDescription.Create(description);

        UpdateModifiedDateTime();

        CheckPolicies();
    }

    #endregion

    #region Project Behaviors



    /// <summary>
    ///
    /// </summary>
    public void AddProject(Project project)
    {
        Projects.Add(project);
        UpdateModifiedDateTime();
    }

    /// <summary>
    ///
    /// </summary>
    public void UpdateProject(string id, string name, string description)
    {
        var project = GetProjectById(id);

        project.Update(name, description);

        UpdateModifiedDateTime();
    }

    /// <summary>
    ///
    /// </summary>
    public void DeleteProject(string id)
    {
        var project = GetProjectById(id);

        Projects.Remove(project);

        UpdateModifiedDateTime();
    }

    /// <summary>
    ///
    /// </summary>
    public Project GetProjectById(string projectId)
    {
        var project = Projects.FirstOrDefault(p => p.Id == projectId);
        if (project == null)
            throw new DomainException(string.Format(ContractsMessages.Not_Found, DomainMetadata.Project));

        return project;
    }

    #endregion

    #region Methods



    /// <summary>
    ///
    /// </summary>
    private void CheckPolicies()
    {
        if (Name == null)
            throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(Name)));

        if (!new OrganizationNameAndDescriptionCannotSameSpecification().IsSatisfiedBy(this))
            throw new DomainException(DomainMessages.Equal_Name_And_Description_Error);
    }

    #endregion
}
