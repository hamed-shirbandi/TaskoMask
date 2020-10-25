using System;
using System.Collections.Generic;
using System.Text;
using TaskoMask.Domain.Core.Commands;

namespace TaskoMask.Domain.Commands.Organizations
{
   public abstract class OrganizationCommand : Command
    {
        public OrganizationCommand()
        {

        }

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string UserId { get; protected set; }
    }
}
