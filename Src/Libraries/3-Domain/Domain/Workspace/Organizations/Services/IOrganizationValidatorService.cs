using System.Threading.Tasks;

namespace TaskoMask.Domain.Workspace.Organizations.Services
{
    /// <summary>
    /// Some validations that need persistence layer to do
    /// </summary>
    public interface IOrganizationValidatorService
    {

        /// <summary>
        /// Check if the name of the organization is unique for its own member
        /// </summary>
        /// <param name="id">If organization is created before, use it to ignore itself when checking the name </param>
        bool OrganizationHasUniqueName(string id, string ownerMemberId, string name);


    }
}
