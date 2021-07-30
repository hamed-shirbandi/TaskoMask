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

namespace TaskoMask.Application.Cards.Commands.Handlers
{
    public class CardsCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateCardCommand, CommandResult>,
         IRequestHandler<UpdateCardCommand, CommandResult>
    {
        private readonly ICardRepository _projectRepository;
        private readonly IMapper _mapper;

        public CardsCommandHandlers(ICardRepository projectRepository, IMapper mapper, IMediator mediator) : base(mediator)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }


        public async Task<CommandResult> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                 await PublishValidationErrorAsync(request);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }


            var project = _mapper.Map<Card>(request);

            var exist = await _projectRepository.ExistByNameAsync(project.Id, project.Name);
            if (exist)
            {
                await PublishValidationErrorAsync(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return new CommandResult(ApplicationMessages.Create_Failed);
            }

            await _projectRepository.CreateAsync(project);
            return new CommandResult(ApplicationMessages.Create_Success,project.Id);

        }



        public async Task<CommandResult> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                await PublishValidationErrorAsync(request);
                return new CommandResult(ApplicationMessages.Update_Failed,request.Id);
            }



            var project = await _projectRepository.GetByIdAsync(request.Id);

            var exist = await _projectRepository.ExistByNameAsync(project.Id, request.Name);
            if (exist)
            {
                await PublishValidationErrorAsync(new DomainNotification("", ApplicationMessages.Name_Already_Exist));
                return new CommandResult(ApplicationMessages.Update_Failed,request.Id);
            }

            project.SetName(request.Name);
            project.SetDescription(request.Description);
            project.SetType(request.Type);

            await _projectRepository.UpdateAsync(project);
            return new CommandResult(ApplicationMessages.Update_Success,project.Id);
        }

    }
}
