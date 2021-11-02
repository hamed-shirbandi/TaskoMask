using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Core.Resources;

namespace TaskoMask.Application.Core.Dtos.Operators
{
    public class OperatorOutputDto : OperatorBasicInfoDto
    {
        [Display(Name = nameof(ApplicationMetadata.RolesCount), ResourceType = typeof(ApplicationMetadata))]
        public long RolesCount { get; set; }
        
    }
}
