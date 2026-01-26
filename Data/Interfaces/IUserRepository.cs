using Domain.Entities;
using Domain.Enums;

namespace Data.Interfaces
{
    public interface IUserRepository
    {
        void CreateUser(User user);
        Task<User?> GetUserByEMail(string email);
        Task<bool> CheckExistingUserById(int userId);
        Task<List<User>> GetUsersByRoleAsync(UserRole role);
        Task<List<User>> GetAllUsers();
    }
}
