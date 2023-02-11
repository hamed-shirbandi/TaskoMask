
namespace TaskoMask.Services.Owners.Write.Api.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOwnerValidatorService
    {

        /// <summary>
        /// Check if the userName of the owner is unique
        /// </summary>
        bool OwnerHasUniqueEmail(string ownerId, string email);


    }
}
