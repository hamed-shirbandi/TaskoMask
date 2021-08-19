namespace TaskoMask.Application.Core.Dtos.Users
{
    public class UserBasicInfoDto: UserBaseDto
    {
        public CreationTimeDto CreationTime { get; set; }
        public string AvatarUrl { get; set; }
    }
}
