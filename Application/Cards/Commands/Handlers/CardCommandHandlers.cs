using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Cards.Commands.Models;
using TaskoMask.Application.Core.Resources;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Notifications;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Entities;
using TaskoMask.Application.Core.Exceptions;
using TaskoMask.Domain.Core.Resources;
using MediatR;

namespace TaskoMask.Application.Cards.Commands.Handlers
{
    public class CardCommandHandlers : BaseCommandHandler,
        IRequestHandler<CreateCardCommand, CommandResult>,
         IRequestHandler<UpdateCardCommand, CommandResult>
    {
        #region Fields

        private readonly ICardRepository _cardRepository;
        private readonly IBoardRepository _boardRepository;
        private readonly IProjectRepository _projectRepository;


        #endregion

        #region Ctors

        public CardCommandHandlers(ICardRepository cardRepository, IDomainNotificationHandler notifications, IProjectRepository projectRepository, IBoardRepository boardRepository) : base(notifications)
        {
            _cardRepository = cardRepository;
            _projectRepository = projectRepository;
            _boardRepository = boardRepository;
        }


        #endregion

        #region Handlers



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var exist = await _cardRepository.ExistByNameAsync("", request.Name);
            if (exist)
            {
                NotifyValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Create_Failed);
            }


            var board = await _boardRepository.GetByIdAsync(request.BoardId);
            if (board == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Board);


            var project = await _projectRepository.GetByIdAsync(board.ProjectId);
            if (project == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Project);


            var card = new Card(name: request.Name, description: request.Description, boardId: request.BoardId, type: request.Type,projectId:project.Id,organizationId:project.OrganizationId);
            if (!IsValid(card))
                return new CommandResult(ApplicationMessages.Create_Failed);

            await _cardRepository.CreateAsync(card);
            return new CommandResult(ApplicationMessages.Create_Success, card.Id);

        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<CommandResult> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetByIdAsync(request.Id);
            if (card == null)
                throw new ApplicationException(ApplicationMessages.Data_Not_exist, DomainMetadata.Card);

            var exist = await _cardRepository.ExistByNameAsync(card.Id, request.Name);
            if (exist)
            {
                NotifyValidationError(request, ApplicationMessages.Name_Already_Exist);
                return new CommandResult(ApplicationMessages.Update_Failed, request.Id);
            }

            card.Update(request.Name, request.Description, request.Type);
            if (!IsValid(card))
                return new CommandResult(ApplicationMessages.Update_Failed);


            await _cardRepository.UpdateAsync(card);
            return new CommandResult(ApplicationMessages.Update_Success, card.Id);
        }


        #endregion

    }
}
