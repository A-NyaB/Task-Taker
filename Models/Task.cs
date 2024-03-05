using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Task_Taker.Models
{
    public class Task
    {

            public int Id { get; set; }

            [Required]
            public string Title { get; set; }

            [Required]
            public string Description { get; set; }

            public int TaskListId { get; set; }

             public int StatusId { get; set; }
            public Status? Status { get; set; }
            public TaskList? TaskList {  get; set; }        
            public int EstimatedTime { get; set; }

            public int? ActualTime { get; set; }

            public bool Completed { get; set; }

            //public List<Comment> Comments { get; set; }
    }
}
