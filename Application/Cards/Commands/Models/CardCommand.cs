using CSharpFunctionalExtensions;
using MediatR;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Enums;

namespace TaskoMask.Application.Cards.Commands.Models
{
    public abstract class CardCommand : BaseCommand
    {
        public CardCommand()
        {

        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public CardType Type { get; protected set; }
        public string BoardId { get; protected set; }
    }
}
