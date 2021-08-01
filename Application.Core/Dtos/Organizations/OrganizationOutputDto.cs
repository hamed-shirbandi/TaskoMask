

namespace TaskoMask.Application.Core.Dtos.Organizations
{
    public class OrganizationOutputDto: OrganizationBasicInfoDto
    {
        public OrganizationReportDto Reports { get; set; }
    }
}
