using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Domain.Commands.Organizations
{
   public class CreateOrganizationCommand : OrganizationCommand
    {
        public CreateOrganizationCommand(string name, string description, string userId)
        {
            Name = name;
            Description = description;
            UserId = userId;
        }  
    }
}
