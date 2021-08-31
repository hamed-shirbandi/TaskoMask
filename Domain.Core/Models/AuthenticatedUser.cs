
namespace TaskoMask.Domain.Core.Models
{
    public class AuthenticatedUser
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
