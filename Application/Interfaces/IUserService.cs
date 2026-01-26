using Application.DTO;
using Domain.Entities;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface IUserService
    {
        void CreateUser(CreateUserRequestDto userDto);
        Task<UserResponseDto> GetUserByEMail(string email);
        Task<List<TechnicianListItemDto>> GetTechnicians();
        Task<List<UserResponseDto>> GetUsersByRoleAsync(UserRole role);
        Task<User> GetUserEntityByEMail(string email);
        Task<bool> CheckExistingUserById(int userId);
    }
}
