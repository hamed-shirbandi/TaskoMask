
namespace TaskoMask.Application.Commands.Models.Organizations
{
   public class UpdateOrganizationCommand : OrganizationCommand
    {
        public UpdateOrganizationCommand(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; private set; }
    }
}
