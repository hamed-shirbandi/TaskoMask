using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Resources;
using TaskoMask.Services.Owners.Write.Domain.Specifications;
using TaskoMask.Services.Owners.Write.Domain.ValueObjects.Projects;
using TaskoMask.BuildingBlocks.Domain.Resources;
using MongoDB.Bson;

namespace TaskoMask.Services.Owners.Write.Domain.Entities
{
    public class Project : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        private Project(string name, string description )
        {
            SetId(ObjectId.GenerateNewId().ToString());

            Name = ProjectName.Create(name);
            Description = ProjectDescription.Create(description) ;

            CheckPolicies();
        }


        #endregion

        #region Properties

        public ProjectName Name { get; private set; }
        public ProjectDescription Description { get; private set; }

        #endregion

        #region Behaviors



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

        #region Methods


        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies()
        {
            if (Name == null)
                throw new DomainException(string.Format(ContractsMessages.Null_Reference_Error, nameof(Name)));

            if (!new ProjectNameAndDescriptionCannotSameSpecification().IsSatisfiedBy(this))
                throw new DomainException(DomainMessages.Equal_Name_And_Description_Error);

        }


        #endregion

    }
}
