using System.ComponentModel.DataAnnotations;

namespace TaskoMask.Application.Core.ViewMoldes.Account
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
