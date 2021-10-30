namespace TaskoMask.Application.Core.Dtos.Roles
{
    public class RoleOutputDto : RoleBasicInfoDto
    {
        public long OperatorsCount { get; set; }
        public long PermissionsCount { get; set; }
        
    }
}
