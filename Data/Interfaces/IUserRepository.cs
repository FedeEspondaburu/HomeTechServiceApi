using Domain.Entities;

namespace Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEMail(string email);
        Task<bool> CheckExistingUserById(int userId);
    }
}
