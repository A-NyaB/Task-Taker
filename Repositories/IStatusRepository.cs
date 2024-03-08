using Task_Taker.Models;

namespace Task_Taker.Repositories
{
    public interface IStatusRepository
    {
        List<Status> GetAll();
    }
}