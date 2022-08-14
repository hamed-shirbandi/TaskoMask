
using TaskoMask.BuildingBlocks.Contracts.Enums;

namespace TaskoMask.BuildingBlocks.Contracts.Dtos.Authorization.Users
{
    public class UserBasicInfoDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public UserType Type { get; set; }

    }
}
