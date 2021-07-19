using System.ComponentModel.DataAnnotations;

namespace TaskoMask.Application.Queries.ViewMoldes.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
