using TaskoMask.Domain.Workspace.Organizations.Entities;
using TaskoMask.Domain.Workspace.Organizations.Services;
using TaskoMask.Domain.Workspace.Organizations.ValueObjects;

namespace TaskoMask.Domain.Workspace.Organizations.Builders
{
    public class OrganizationBuilder
    {
        #region Fields

        private OrganizationName name;
        private OrganizationDescription description;
        private OrganizationOwnerMemberId ownerMemberId;
        private IOrganizationValidatorService organizationValidatorService;

        #endregion

        #region Ctors



        /// <summary>
        /// 
        /// </summary>
        private OrganizationBuilder()
        {
        }



        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public static OrganizationBuilder Init()
        {
            return new OrganizationBuilder();
        }



        /// <summary>
        /// 
        /// </summary>
        public OrganizationBuilder WithName(string name)
        {
            this.name = OrganizationName.Create(name);
            return this;
        }



        /// <summary>
        /// 
        /// </summary>
        public OrganizationBuilder WithDescription(string description)
        {
            this.description = OrganizationDescription.Create(description);
            return this;
        }



        /// <summary>
        /// 
        /// </summary>
        public OrganizationBuilder WithOwnerMemberId(string ownerMemberId)
        {
            this.ownerMemberId = OrganizationOwnerMemberId.Create(ownerMemberId);
            return this;
        }



        /// <summary>
        /// 
        /// </summary>
        public OrganizationBuilder WithValidator(IOrganizationValidatorService organizationValidatorService)
        {
            this.organizationValidatorService = organizationValidatorService;
            return this;
        }



        /// <summary>
        /// 
        /// </summary>
        public Organization Build() => Organization.CreateOrganization(name, description, ownerMemberId, organizationValidatorService);


        #endregion
    }
}
