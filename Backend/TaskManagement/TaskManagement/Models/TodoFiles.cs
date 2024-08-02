namespace TaskManagement.Models
{
    public class TodoFiles:BaseDateModel
    {
        public TodoFiles()
        {
            Id= Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string UniqueName { get; set; }
        public Guid TodoId { get; set; }
        public virtual Todo Todo{ get; set; }
    }
}
