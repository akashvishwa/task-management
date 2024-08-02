using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class User:BaseDateModel
    {
        public User()
        {
            UserId = Guid.NewGuid();
        }

        [Key]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public Guid UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }
        public Guid? ManagerId { get; set; }

    }
}
