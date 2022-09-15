using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;

namespace TaskoMask.Services.Identity.Application.UseCases.UserLogin
{
    public class UserLoginRequest: IRequest<Result>
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberLogin { get; set; }

        public string ReturnUrl { get; set; }

    }
}
