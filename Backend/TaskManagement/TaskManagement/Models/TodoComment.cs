using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Models
{
    public class TodoComment:BaseDateModel
    {
        public TodoComment()
        {
             Id = Guid.NewGuid();             
        }
        [Key]
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public Guid TodoId { get; set; }
        public virtual Todo Todo { get; set; }
    }
}
