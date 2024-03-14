namespace Task_Taker.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ListTitle { get; set; }
        public UserProfile? UserProfile { get; set; }
    }
}
