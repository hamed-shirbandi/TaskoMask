using System.Linq;
using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.Share.Helpers;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.DomainModel.Workspace.Owners.Specifications
{
    internal class OwnerMaxOrganizationsSpecification : ISpecification<Owner>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Owner owner)
        {
            return owner.Organizations.Count(p => p.IsDeleted == false) <= DomainConstValues.Owner_Max_Organizations_Count;
        }
    }
}
