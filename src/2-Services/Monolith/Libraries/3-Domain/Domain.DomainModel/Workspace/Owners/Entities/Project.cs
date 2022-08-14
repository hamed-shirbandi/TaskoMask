using TaskoMask.Services.Monolith.Domain.Core.Exceptions;
using TaskoMask.Services.Monolith.Domain.Core.Models;
using TaskoMask.Services.Monolith.Domain.Share.Resources;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Specifications;
using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.ValueObjects.Projects;

namespace TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities
{
    public class Project : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        private Project(string name, string description )
        {
            Name = ProjectName.Create(name);
            Description = ProjectDescription.Create(description) ;

            CheckPolicies();
        }


        #endregion

        #region Properties

        public ProjectName Name { get; private set; }
        public ProjectDescription Description { get; private set; }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public static Project Create(string name, string description)
        {
            return new Project(name, description);
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




        #endregion

        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies()
        {
            if (Name == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Name)));

            if (!new ProjectNameAndDescriptionCannotSameSpecification().IsSatisfiedBy(this))
                throw new DomainException(DomainMessages.Equal_Name_And_Description_Error);

        }


        #endregion

    }
}
