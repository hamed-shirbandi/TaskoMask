using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Domain.Tests.Unit.TestData.DataBuilders
{
    internal class OwnerBuilder
    {
        public string Id { get; private set; }
        public string Email { get; private set; }
        public string DisplayName { get; private set; }


        private OwnerBuilder()
        {

        }


        public static OwnerBuilder Init()
        {
            return new OwnerBuilder();
        }


        public OwnerBuilder WithId(string id)
        {
            Id = id;
            return this;
        }



        public OwnerBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }


        public OwnerBuilder WithDisplayName(string displayName)
        {
            DisplayName = displayName;
            return this;
        }



        public Owner Build()
        {
            return Owner.CreateOwner(Id, DisplayName, Email);
        }


    }
}
