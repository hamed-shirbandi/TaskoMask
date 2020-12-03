using CSharpFunctionalExtensions;
using MediatR;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Commands.Models.Boards
{
    public abstract class BoardCommand : Command
    {
        public BoardCommand()
        {

        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string ProjectId { get; protected set; }
    }
}
