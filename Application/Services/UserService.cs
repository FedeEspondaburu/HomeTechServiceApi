using Application.DTO;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Shared.Exceptions;
using Shared.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptographyService _cryptographyService;

        public UserService(IUserRepository userRepository, ICryptographyService cryptographyService)
        {
            _userRepository = userRepository;
            _cryptographyService = cryptographyService;
        }

        public Task<bool> CheckExistingUserById(int userId)
        {
            return _userRepository.CheckExistingUserById(userId);
        }

        public void CreateUser(CreateUserRequestDto userDto)
        {
            var User = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Document = userDto.Document,
                EMail = userDto.EMail,
                PasswordHash = _cryptographyService.EncryptPassword(userDto.Password),
                Role = userDto.Role
            };
            if (userDto.Role.Equals(UserRole.Client))
            {
                User.Address = new Address
                {
                    Direction = userDto.Direction!,
                    City = userDto.City!,
                    Province = userDto.Province!,
                    PostalCode = (int)userDto.PostalCode!
                };
            }
            _userRepository.CreateUser(User);
        }

        public async Task<List<TechnicianListItemDto>> GetTechnicians()
        {
            var users = await GetUsersByRoleAsync(UserRole.Technician);
            return users.Select(user => new TechnicianListItemDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Document = user.Document
            }).ToList();
        }

        public async Task<UserResponseDto> GetUserByEMail(string email)
        {
            var user = await _userRepository.GetUserByEMail(email);
            if (user == null)
            {
                throw new DataNotFoundException($"User with EMail '{email}'");
            }
            return MapToDto(user);
        }

        public Task<User?> GetUserEntityByEMail(string email)
        {
            return _userRepository.GetUserByEMail(email);
        }

        public async Task<List<UserResponseDto>> GetUsersByRoleAsync(UserRole role)
        {
            var users = await _userRepository.GetUsersByRoleAsync(role);
            return users.Select(MapToDto).ToList();
        }

        private UserResponseDto MapToDto(User user)
        {
            return new UserResponseDto
            {
                Id = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Document = user.Document,
                EMail = user.EMail,
                RoleName = Enum.GetName(user.Role)!,
            };
        }
    }
}
