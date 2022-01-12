using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Dtos.Common.Users;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Administration.Operators
{
    public class OperatorBasicInfoDto: UserBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.RolesId), ResourceType = typeof(ApplicationMetadata))]
        public string[] RolesId { get; set; }

    }
}
