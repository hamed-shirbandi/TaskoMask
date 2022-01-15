using TaskoMask.Domain.Workspace.Organizations.Entities;
using TaskoMask.Domain.Workspace.Organizations.ValueObjects;

namespace TaskoMask.Domain.Workspace.Organizations.Builders
{
    public class ProjectBuilder
    {
        #region Properties

        public ProjectName Name { get; private set; }
        public ProjectDescription Description { get; private set; }
        public ProjectOrganizationId OrganizationId { get; private set; }

        #endregion

        #region Ctors



        /// <summary>
        /// 
        /// </summary>
        private ProjectBuilder()
        {
        }



        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public static ProjectBuilder Init()
        {
            return new ProjectBuilder();
        }



        /// <summary>
        /// 
        /// </summary>
        public ProjectBuilder WithName(string name)
        {
            Name = ProjectName.Create(name);
            return this;
        }



        /// <summary>
        /// 
        /// </summary>
        public ProjectBuilder WithDescription(string description)
        {
            Description = ProjectDescription.Create(description);
            return this;
        }




        /// <summary>
        /// 
        /// </summary>
        public Project Build() => Project.Create(Name, Description, OrganizationId);


        #endregion
    }
}
