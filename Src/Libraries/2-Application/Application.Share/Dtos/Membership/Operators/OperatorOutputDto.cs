using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Ownership.Operators
{
    public class OperatorOutputDto : OperatorBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.RolesCount), ResourceType = typeof(ApplicationMetadata))]
        public long RolesCount { get; set; }
        
    }
}
