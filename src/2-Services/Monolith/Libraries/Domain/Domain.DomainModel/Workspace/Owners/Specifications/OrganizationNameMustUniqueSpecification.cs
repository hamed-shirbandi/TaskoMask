﻿using System.Linq;
using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.DomainModel.Workspace.Owners.Specifications
{
    internal class OrganizationNameMustUniqueSpecification : ISpecification<Owner>
    {

        /// <summary>
        /// 
        /// </summary>
        public bool IsSatisfiedBy(Owner owner)
        {
            var organizations = owner.Organizations.ToList();

            var organizationsCount = organizations.Count;
            if (organizationsCount < 2)
                return true;

            var distincOrganizationsCount = organizations.Select(p => p.Name).Distinct().Count();
            return organizationsCount == distincOrganizationsCount;
        }
    }
}
