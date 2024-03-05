using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using Task_Taker.Models;
using Task_Taker.Utils;
//changing category to task list and making usertype status
// i might need to rebuild my database. I don't have a place for my user information to join on to my tasks but is it that important? how could it be saved?
namespace Task_Taker.Repositories
{
    public class TaskRepository : BaseRepository, ITaskRepository
    {
        public TaskRepository(IConfiguration config) : base(config) { }
        public List<Task_Taker.Models.Task> GetAllTasks()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                       SELECT t.Id, t.TaskListId, t.Title, t.Description, t.StatusId, t.EstimatedTime,
                        tl.UserId, t.Completed, tl.ListTitle, s.Progress
                        FROM Task t
                        LEFT JOIN TaskList tl ON t.TaskListId = tl.id
                        LEFT JOIN Status s ON t.StatusId = s.Id";

                    var reader = cmd.ExecuteReader();

                    var Tasks = new List<Task_Taker.Models.Task>();

                    while (reader.Read())
                    {
                        Tasks.Add(NewTaskFromReader(reader));
                    }
                    reader.Close();

                    return Tasks;
                }
            }
        }

        public List<Task_Taker.Models.Task> GetAllTasksByList(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                      SELECT t.Id, t.TaskListId, t.Title, t.Description, t.StatusId, t.EstimatedTime, t.ActualTime,
                        tl.UserId, t.Completed, tl.ListTitle, s.Progress
                        FROM Task t
                        LEFT JOIN TaskList tl ON t.TaskListId = tl.id
                        LEFT JOIN Status s ON t.StatusId = s.Id
                        WHERE tl.Id = @tasklistid";

                    cmd.Parameters.AddWithValue("@tasklistid", id);
                    var reader = cmd.ExecuteReader();

                    var Tasks = new List<Task_Taker.Models.Task>();

                    while (reader.Read())
                    {
                        Tasks.Add(NewTaskFromReader(reader));
                    }
                    reader.Close();

                    return Tasks;
                }
            }
        }
        //shows just one task
        public Task_Taker.Models.Task GetTaskById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                       SELECT t.Id, t.TaskListId, t.Title, t.Description, t.StatusId, t.EstimatedTime, t.ActualTime,
                        tl.UserId, t.Completed, tl.ListTitle, s.Progress
                        FROM Task t
                        LEFT JOIN TaskList tl ON t.TaskListId = tl.id
                        LEFT JOIN Status s ON t.StatusId = s.Id
                        WHERE t.id = @id";

                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();

                    Task_Taker.Models.Task task = null;

                    if (reader.Read())
                    {
                        task = NewTaskFromReader(reader);
                    }
                    reader.Close();

                    return task;
                }
            }
        }
        public void Add(Task_Taker.Models.Task task)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Task (
                            TaskListId, Title, Description, StatusId, EstimatedTime, ActualTime,
                            Completed )
                        OUTPUT INSERTED.ID
                        VALUES (
                            @TaskListId, @Title, @Description, @StatusId, @EstimatedTime, @ActualTime,
                            @Completed )"; 
                    cmd.Parameters.AddWithValue("@TaskListId", task.TaskListId);
                    cmd.Parameters.AddWithValue("@Title", task.Title);
                    cmd.Parameters.AddWithValue("@Description", task.Description);
                    cmd.Parameters.AddWithValue("@StatusId", task.StatusId);
                    cmd.Parameters.AddWithValue("@EstimatedTime", DbUtils.ValueOrDBNull(task.EstimatedTime));
                    cmd.Parameters.AddWithValue("@ActualTime", DbUtils.ValueOrDBNull(task.ActualTime));
                    cmd.Parameters.AddWithValue("@Completed", task.Completed);

                    task.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void EditTask(Task_Taker.Models.Task task)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                         UPDATE Task
                            SET 
                                TaskListId = @TaskListId,
                                [Title] = @Title,
                                Description = @Description,
                                StatusId = @StatusId,
                                EstimatedTime = @EstimatedTime,
                                ActualTime = @ActualTime,
                                Completed = @Completed
                            WHERE Id = @Id";

                    cmd.Parameters.AddWithValue("@Id", task.Id);
                    cmd.Parameters.AddWithValue("@TaskListId", task.TaskListId);
                    cmd.Parameters.AddWithValue("@Title", task.Title);
                    cmd.Parameters.AddWithValue("@Description", task.Description);
                    cmd.Parameters.AddWithValue("@StatusId", task.StatusId);
                    cmd.Parameters.AddWithValue("@EstimatedTime", task.EstimatedTime);
                    cmd.Parameters.AddWithValue("@ActualTime", DbUtils.ValueOrDBNull(task.ActualTime));
                    cmd.Parameters.AddWithValue("@Completed", task.Completed);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTask(int taskId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            DELETE FROM Task
                            WHERE Id = @id
                        ";

                    cmd.Parameters.AddWithValue("@id", taskId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Task_Taker.Models.Task NewTaskFromReader(SqlDataReader reader)
        {
            return new Task_Taker.Models.Task()
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                TaskListId = reader.GetInt32(reader.GetOrdinal("TaskListId")),
                TaskList = new TaskList()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("StatusId")),
                    UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                    ListTitle = reader.GetString(reader.GetOrdinal("ListTitle"))
                },
                Title = reader.GetString(reader.GetOrdinal("Title")),
                Description = reader.GetString(reader.GetOrdinal("Description")),
                StatusId = reader.GetInt32(reader.GetOrdinal("StatusId")),
                Status = new Status()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("StatusId")),
                    Progress = reader.GetString(reader.GetOrdinal("Progress"))
                },
                EstimatedTime = reader.GetInt32(reader.GetOrdinal("EstimatedTime")),
                //ActualTime = reader.GetInt32(reader.GetOrdinal("ActualTime")),
                Completed = reader.GetBoolean(reader.GetOrdinal("Completed")),
            };
        }
    }

}
