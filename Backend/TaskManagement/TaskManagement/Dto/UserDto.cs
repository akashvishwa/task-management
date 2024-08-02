namespace TaskManagement.Dto
{
    public class UserDto
    {
        public Guid? UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public Guid UserTypeId { get; set; }
        public Guid? ManagerId { get; set; }
    }
}
