using Task_Taker.Models;

namespace Task_Taker.Repositories
{
    public interface IUserRepository
    {
        void Add(UserProfile userProfile);
        UserProfile GetByEmail(string email);
    }
}