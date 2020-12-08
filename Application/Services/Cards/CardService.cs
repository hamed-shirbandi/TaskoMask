using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using System.Threading.Tasks;
using TaskoMask.Application.Commands.Models.Cards;
using TaskoMask.Application.Queries.Models.Cards;
using TaskoMask.Application.Queries.Models.Projects;
using TaskoMask.Application.Services.Cards.Dto;
using TaskoMask.Application.ViewMoldes;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Application.Services.Cards
{
    public class CardService : ICardService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CardService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }



        public async Task<Result<CommandResult>> CreateAsync(CardInput input)
        {
            var project = _mapper.Map<CreateCardCommand>(input);

            return await _mediator.Send(project);
        }


        public async Task<Result<CommandResult>> UpdateAsync(CardInput input)
        {
            var updateCommand = _mapper.Map<UpdateCardCommand>(input);
            return await _mediator.Send(updateCommand);
        }

        public async Task<CardOutput> GetByIdAsync(string id)
        {
            var query = new GetCardByIdQuery(id);
            return await _mediator.Send(query);
        }


        public async Task<CardInput> GetByIdToUpdateAsync(string id)
        {
            var organization = await GetByIdAsync(id);
            return _mapper.Map<CardInput>(organization);
        }



    
        public async Task<long> CountAsync()
        {
            var query = new GetCardsCountQuery();
            return  await _mediator.Send(query);
        }

       
    }
}
