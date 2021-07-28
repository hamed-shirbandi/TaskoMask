using TaskoMask.Application.Core.Helpers;
using FluentValidation.Results;
using MediatR;
using TaskoMask.Application.Core.Commands;

namespace TaskoMask.Application.Users.Commands.Models
{
    public abstract class UserCommand : BaseCommand
    {
        public UserCommand()
        {

        }

        public string DisplayName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
    }
}
