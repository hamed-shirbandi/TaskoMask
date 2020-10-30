

namespace TaskoMask.Application.Services.Organizations.Dto
{
    public class OrganizationOutput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string CreateDateTime { get; set; }
        public int ProjectsCount { get; set; }
        public int BoardsCount { get; set; }
        public int TasksCount { get; set; }
    }
}
