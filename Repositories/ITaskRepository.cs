





namespace Task_Taker.Repositories
{
    public interface ITaskRepository
    {
        void Add(Models.Task task);
        void DeleteTask(int taskId);
        void EditTask(Models.Task task);
        List<Models.Task> GetAllTasks();
        List<Models.Task> GetAllTasksByList(int id);
        Models.Task GetTaskById(int id);
    }
}