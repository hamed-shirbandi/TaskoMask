using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Dtos.Common.Users;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Administration.Operators
{
    public class OperatorBasicInfoDto: UserBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.RolesId), ResourceType = typeof(ApplicationMetadata))]
        public string[] RolesId { get; set; }

    }
}
