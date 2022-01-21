using System.Linq;
using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.WriteModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.WriteModel.Workspace.Owners.Specifications
{
    internal class OrganizationMaxProjectsSpecification : ISpecification<Owner>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Owner owner)
        {
            foreach (var organization in owner.Organizations)
                if (organization.Projects.Count > DomainConstValues.Organization_Max_Projects_Count)
                    return false;

            return true;
        }
    }
}
