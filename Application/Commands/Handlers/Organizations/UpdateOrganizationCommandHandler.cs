using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Organizations;
using TaskoMask.Application.Resources;
using TaskoMask.Domain.Data;
using TaskoMask.Domain.Models;

namespace TaskoMask.Application.Commands.Handlers.Organizations
{
    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand, Result>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        public UpdateOrganizationCommandHandler(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }


        public async Task<Result> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                //TODO add error to domain notifications

                return Result.Failure(ApplicationMessages.Update_Failed);
            }


            var organization = await _organizationRepository.GetByIdAsync(request.Id);
            organization.SetName(request.Name);
            organization.SetDescription(request.Description);
            await _organizationRepository.UpdateAsync(organization);
            return Result.Success(ApplicationMessages.Update_Success);
        }
    }
}
