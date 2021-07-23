using CSharpFunctionalExtensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskoMask.Application.Cards.Queries.Models;
using TaskoMask.Domain.Data;

namespace TaskoMask.Application.Cards.Queries.Handlers
{
    public class GetCardsCountQueryHandler : IRequestHandler<GetCardsCountQuery, long>
    {
        private readonly ICardRepository _projectRepository;
        public GetCardsCountQueryHandler(ICardRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<long> Handle(GetCardsCountQuery request, CancellationToken cancellationToken)
        {
            return await _projectRepository.CountAsync();
        }
    }
}
