using TaskoMask.Domain.Team.Entities.Organizations.ValueObjects;

namespace TaskoMask.Domain.Team.Entities.Organizations
{
    public class OrganizationBuilder
    {
        #region Properties

        public OrganizationName Name { get; private set; }
        public OrganizationDescription Description { get; private set; }
        public OrganizationOwnerMemberId OwnerMemberId { get; private set; }

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
            Name = OrganizationName.Create(name);
            return this;
        }



        /// <summary>
        /// 
        /// </summary>
        public OrganizationBuilder WithDescription(string description)
        {
            Description = OrganizationDescription.Create(description);
            return this;
        }



        /// <summary>
        /// 
        /// </summary>
        public OrganizationBuilder WithOwnerMemberId(string ownerMemberId)
        {
            OwnerMemberId = OrganizationOwnerMemberId.Create(ownerMemberId);
            return this;
        }



        /// <summary>
        /// 
        /// </summary>
        public Organization Build() => Organization.Create(Name, Description, OwnerMemberId);


        #endregion
    }
}
