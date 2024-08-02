namespace TaskManagement.Dto
{
    public class TodoFileDto
    {
        public Guid FileId { get; set; }
        public string Name { get; set; }
        public Guid TodoId { get; set; }
        public IFormFile File { get; set; }
    }
}
