namespace TaskManagement.Models
{
    public class BaseDateModel
    {
        public BaseDateModel()
        {
              CreatedOn = DateTime.Now;
        }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
