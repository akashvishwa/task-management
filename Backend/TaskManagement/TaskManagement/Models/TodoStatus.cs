namespace TaskManagement.Models
{
    public class TodoStatus:BaseDateModel
    {
        public Guid TodoStatusId { get; set; }
        public string Name { get; set; }
    }
}
