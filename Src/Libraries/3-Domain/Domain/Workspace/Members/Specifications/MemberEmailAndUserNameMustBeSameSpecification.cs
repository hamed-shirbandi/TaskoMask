using TaskoMask.Domain.Core.Specifications;
using TaskoMask.Domain.Workspace.Members.Entities;

namespace TaskoMask.Domain.Workspace.Members.Specifications
{
    internal class MemberEmailAndUserNameMustBeSameSpecification : ISpecification<Member>
    {
        public bool IsSatisfiedBy(Member member)
        {
            if (member.Identity.Email.Value.ToLower() != member.Authentication.UserName.Value.ToLower())
                return false;
            return true;
        }
    }
}
