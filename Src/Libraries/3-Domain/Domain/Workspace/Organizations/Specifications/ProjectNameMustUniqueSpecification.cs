using System.Linq;
using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.Workspace.Organizations.Entities;

namespace TaskoMask.Domain.Workspace.Organizations.Specifications
{

    internal class ProjectNameMustUniqueSpecification : ISpecification<Organization>
    {

        public bool IsSatisfiedBy(Organization organization)
        {
            //* It is better to do the things without using Domain Services if it is possible
            //So it can be done by using the domain knowledge
            //Using lots of Domain Service make the model like Anemic Model
            var projectsCount = organization.Projects.Count;
            if (projectsCount<2)
                return true;

            var distincProjectsCount = organization.Projects.Select(p => p.Name).Distinct().Count();

            return projectsCount == distincProjectsCount;

        }
    }
}
