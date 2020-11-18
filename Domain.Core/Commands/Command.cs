using CSharpFunctionalExtensions;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskoMask.Domain.Core.Commands
{
   public class Command: IRequest<Result>
    {
        public ValidationResult ValidationResult { get; set; }

    }
}
