namespace TaskManagement.Dto
{
    public class TodoCommentDto
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public Guid TodoId { get; set; }
    }
}
