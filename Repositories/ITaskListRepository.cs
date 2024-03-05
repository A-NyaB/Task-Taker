using Task_Taker.Models;

namespace Task_Taker.Repositories
{
    public interface ITaskListRepository
    {
        void Add(TaskList taskList);
        void Delete(int taskListId);
        List<TaskList> GetAll();
        List<TaskList> GetById(int id);
        TaskList GetTaskListById(int id);
        void UpdateTaskList(TaskList taskList);
    }
}