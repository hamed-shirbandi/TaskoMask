using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Projects;
using TaskoMask.Application.Resources;
using TaskoMask.Domain.Core.Commands;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Commands.Handlers.Projects
{
    public class CreateProjectCommandHandler :CommandHandler, IRequestHandler<CreateProjectCommand, Result<string>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper, IMediator mediator) : base(mediator)
        {
            _projectRepository = projectRepository;
            _mediator = mediator;
            _mapper = mapper;
        }


        public async Task<Result<string>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Result.Failure<string>(ApplicationMessages.Create_Failed);
            }

            //TODO check if name is exist and add error to DomainNotification

            var project = _mapper.Map<Project>(request); 
            await _projectRepository.CreateAsync(project);
            return Result.Success(ApplicationMessages.Create_Success);
        }
    }
}
