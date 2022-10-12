using System.Linq;
using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Owners.Write.Domain.Entities;

namespace TaskoMask.Services.Owners.Write.Domain.Specifications
{
    internal class OwnerMaxOrganizationsSpecification : ISpecification<Owner>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Owner owner)
        {
            return owner.Organizations.Count() <= DomainConstValues.Owner_Max_Organizations_Count;
        }
    }
}
