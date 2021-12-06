
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Team.Members
{
    public class MemberOutputDto : MemberBasicInfoDto
    {
        /// <summary>
        /// Member Organizations count as an owner or as an invited member
        /// </summary>
        [Display(Name = nameof(ApplicationMetadata.OrganizationsCount), ResourceType = typeof(ApplicationMetadata))]
        public long OrganizationsCount { get; set; }

    }
}
