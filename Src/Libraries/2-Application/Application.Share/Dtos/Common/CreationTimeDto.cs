using System;
using System.ComponentModel.DataAnnotations;
using TaskoMask.Application.Share.Resources;

namespace TaskoMask.Application.Share.Dtos.Common
{
    public class CreationTimeDto
    {

        [Display(Name = nameof(ApplicationMetadata.CreateDateTime), ResourceType = typeof(ApplicationMetadata))]
        public DateTime CreateDateTime { get; private set; }

        [Display(Name = nameof(ApplicationMetadata.CreateDateTime), ResourceType = typeof(ApplicationMetadata))]
        public string CreateDateTimeString { get; private set; }

        [Display(Name = nameof(ApplicationMetadata.ModifiedDateTime), ResourceType = typeof(ApplicationMetadata))]
        public DateTime ModifiedDateTime { get; private set; }


        [Display(Name = nameof(ApplicationMetadata.ModifiedDateTime), ResourceType = typeof(ApplicationMetadata))]
        public string ModifiedDateTimeString { get; set; }

        [Display(Name = nameof(ApplicationMetadata.CreateDay), ResourceType = typeof(ApplicationMetadata))]
        public int CreateDay { get; set; }

        [Display(Name = nameof(ApplicationMetadata.CreateMonth), ResourceType = typeof(ApplicationMetadata))]
        public int CreateMonth { get; set; }

        [Display(Name = nameof(ApplicationMetadata.CreateYear), ResourceType = typeof(ApplicationMetadata))]
        public int CreateYear { get; set; }
    }
}
