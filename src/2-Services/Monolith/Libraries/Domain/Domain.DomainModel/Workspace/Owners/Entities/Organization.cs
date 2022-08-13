﻿using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;
using TaskoMask.Domain.DomainModel.Workspace.Owners.ValueObjects.Organizations;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Specifications;
using System.Collections.Generic;
using System.Linq;

namespace TaskoMask.Domain.DomainModel.Workspace.Owners.Entities
{
    public class Organization : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        private Organization(string name, string description)
        {
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

        #region Public Organization Methods



        /// <summary>
        /// 
        /// </summary>
        public static Organization CreateOrganization(string name, string description )
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

            base.UpdateModifiedDateTime();

            CheckPolicies();
        }




        #endregion

        #region Public Project Methods



        /// <summary>
        /// 
        /// </summary>
        public void AddProject(Project project)
        {
            Projects.Add(project);
            base.UpdateModifiedDateTime();
        }



        /// <summary>
        /// 
        /// </summary>
        public void UpdateProject(string id, string name, string description)
        {
            var project = Projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Project));

            project.Update(name, description);

            base.UpdateModifiedDateTime();
        }



        /// <summary>
        /// 
        /// </summary>
        public void DeleteProject(string id)
        {
            var project = Projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
                throw new DomainException(string.Format(DomainMessages.Not_Found, DomainMetadata.Project));

            Projects.Remove(project);

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

            if (!new OrganizationNameAndDescriptionCannotSameSpecification().IsSatisfiedBy(this))
                throw new DomainException(DomainMessages.Equal_Name_And_Description_Error);

        }


        #endregion

    }
}
