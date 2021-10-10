using System;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Commands;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Administration.Operators.Commands.Models
{
    public class UpdateOperatorRolesCommand : BaseCommand
    {

        public UpdateOperatorRolesCommand(string id, string[] rolesId)
        {
            Id = id;
            RolesId = rolesId;
        }



        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Id { get; set; }

        public string[] RolesId { get; set; }

    }
}
