using System.Linq;
using TaskoMask.BuildingBlocks.Domain.Specifications;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Services.Owners.Write.Domain.Entities;

namespace TaskoMask.Services.Owners.Write.Domain.Specifications
{
    internal class OrganizationMaxProjectsSpecification : ISpecification<Owner>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Owner owner)
        {
            foreach (var organization in owner.Organizations)
                if (organization.Projects.Count() > DomainConstValues.Organization_Max_Projects_Count)
                    return false;

            return true;
        }
    }
}
