using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserEntityByEMail(string email);
        Task<bool> CheckExistingUserById(int userId);
    }
}
