using Application.Interfaces;
using Domain.Entities;
using Data.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CheckExistingUserById(int userId)
        {
            return await _userRepository.CheckExistingUserById(userId);
        }

        public async Task<User?> GetUserEntityByEMail(string email)
        {
            return await _userRepository.GetUserByEMail(email);
        }

    }
}
