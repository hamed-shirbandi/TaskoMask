

namespace TaskoMask.Application.Services.Projects.Dto
{
    public class ProjectOutput
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OrganizationId { get; set; }
        public string CreateDateTime { get; set; }
        public int BoardsCount { get; set; }
        public int TasksCount { get; set; }
    }
}
