using CSharpFunctionalExtensions;
using MediatR;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Commands.Models.Cards
{
    public abstract class CardCommand : Command
    {
        public CardCommand()
        {

        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string BoardId { get; protected set; }
    }
}
