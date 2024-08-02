using TaskManagement.Models;

namespace TaskManagement.Dto
{
    public class TodoDto
    {
        public Guid TodoId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid TodoStatusId { get; set; }
        public string? Notes { get; set; }
        public DateTime? EndingDate { get; set; }
    }
}
