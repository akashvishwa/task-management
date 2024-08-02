using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class UserType:BaseDateModel
    {
        public UserType()
        {
            UserTypeId = Guid.NewGuid();
        }

        [Key]
        public Guid UserTypeId { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
