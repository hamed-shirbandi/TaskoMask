using CSharpFunctionalExtensions;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Models;

namespace TaskoMask.Domain.Core.Commands
{
    public class CommandResult 
    {
        public CommandResult(string id,string message)
        {
            SavedEntityId = id;
            SuccessMessage = message;
        }

        public string  SavedEntityId { get; private set; }
        public string  SuccessMessage { get; private set; }
    }

}
