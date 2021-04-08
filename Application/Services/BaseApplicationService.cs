using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskoMask.Application.Services
{
    public abstract class BaseApplicationService
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _mapper;

        protected BaseApplicationService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
    }
}
