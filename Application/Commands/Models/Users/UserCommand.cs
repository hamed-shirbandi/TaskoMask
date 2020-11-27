using CSharpFunctionalExtensions;
using FluentValidation.Results;
using MediatR;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Commands.Models.Users
{
    public abstract class UserCommand : Command
    {
        public UserCommand()
        {

        }

        public string DisplayName { get; protected set; }

    }
}
