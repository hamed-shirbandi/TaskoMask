using TaskoMask.Application.Core.Dtos.Users;

namespace TaskoMask.Application.Core.Dtos.Operators
{
    public class OperatorBasicInfoDto: UserBasicInfoDto
    {
        public string[] RolesId { get; set; }

    }
}
