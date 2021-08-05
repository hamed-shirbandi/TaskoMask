using AutoMapper;
using TaskoMask.Application.Core.Helpers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Cards.Commands.Models;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Domain.Core.Notifications;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;

namespace TaskoMask.Application.Cards.Commands.Handlers
{
    public class CardsCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateCardCommand, CommandResult>,
         IRequestHandler<UpdateCardCommand, CommandResult>
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;

        public CardsCommandHandlers(ICardRepository cardRepository, IMapper mapper, IMediator mediator) : base(mediator)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }


        public async Task<CommandResult> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                 await PublishValidationErrorAsync(request);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }


            var existBoardId = true;
            if (!existBoardId)
                throw new ApplicationException(string.Format(ApplicationMessages.Invalid_ForeignKey, nameof(request.BoardId)));

            var exist = await _cardRepository.ExistByNameAsync("", request.Name);
            if (exist)
            {
                await PublishValidationErrorAsync(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            var card = _mapper.Map<Card>(request);

            await _cardRepository.CreateAsync(card);
            return new CommandResult(ApplicationMessages.Create_Success,card.Id);

        }



        public async Task<CommandResult> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await PublishValidationErrorAsync(request);
                return new CommandResult(ApplicationMessages.Update_Failed,request.Id);
            }



            var card = await _cardRepository.GetByIdAsync(request.Id);
            if (card == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Card);

            var exist = await _cardRepository.ExistByNameAsync(card.Id, request.Name);
            if (exist)
            {
                await PublishValidationErrorAsync(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return new CommandResult(ApplicationMessages.Update_Failed,request.Id);
            }

            card.SetName(request.Name);
            card.SetDescription(request.Description);
            card.SetType(request.Type);

            await _cardRepository.UpdateAsync(card);
            return new CommandResult(ApplicationMessages.Update_Success,card.Id);
        }

    }
}
