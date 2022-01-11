using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Workspace.Projects.Commands.Models
{
   public class UpdateProjectCommand : ProjectBaseCommand
    {
        public UpdateProjectCommand(string id, string name, string description,string organizationId)
        {
            Id = id;
            Name = name;
            Description = description;
            OrganizationId = organizationId;
        }

        [Required(ErrorMessageResourceName = nameof(ApplicationMetadata.Required), ErrorMessageResourceType = typeof(ApplicationMetadata))]
        public string Id { get; }


    }
}
