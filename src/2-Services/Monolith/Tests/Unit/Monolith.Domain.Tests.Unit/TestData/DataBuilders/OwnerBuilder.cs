using TaskoMask.Services.Monolith.Domain.DomainModel.Workspace.Owners.Entities;

namespace TaskoMask.Services.Monolith.Domain.Tests.Unit.TestData.DataBuilders
{
    internal class OwnerBuilder
    {
        public string Email { get; private set; }
        public string DisplayName { get; private set; }


        private OwnerBuilder()
        {

        }


        public static OwnerBuilder Init()
        {
            return new OwnerBuilder();
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



        public Owner RegisterOwner()
        {
            return Owner.RegisterOwner(DisplayName, Email);
        }


    }
}
