using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Projects;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Commands.Handlers.Projects
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Result>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public CreateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }


        public async Task<Result> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            //TODO request validation

            var project = _mapper.Map<Project>(request); 
            await _projectRepository.CreateAsync(project);
            return Result.Success();
        }
    }
}
