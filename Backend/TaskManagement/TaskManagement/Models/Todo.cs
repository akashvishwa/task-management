using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class Todo:BaseDateModel
    {
        public Todo()
        {
            TodoId = Guid.NewGuid();
        }
        [Key]
        public Guid TodoId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid EmployeeId {  get; set; }
        public Guid TodoStatusId { get; set; }
        public virtual TodoStatus TodoStatus { get; set; }
        public string? Notes { get; set; }
        public DateTime? EndingDate { get; set; }

    }
}
