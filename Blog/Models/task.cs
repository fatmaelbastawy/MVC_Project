namespace Stor.Models
{
    public class task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime AssignDate { get; set; }
        public int categoryId { get; set; }
        public TaskCategory TaskCategory { get; set; }
        public User User { get; set; }
        public Status Status { get; set; }
    }
    public enum Status
    {
        Open, 
        InProgress,
        Done
    }
}