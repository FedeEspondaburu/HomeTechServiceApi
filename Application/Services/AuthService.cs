using Application.DTO;
using Application.Interfaces;
using Shared.Interfaces;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ICryptographyService _cryptographyService;
        private readonly IUserService _userService;
        public AuthService(ICryptographyService cryptographyService, IUserService userService)
        {
            _cryptographyService = cryptographyService;
            _userService = userService;
        }

        public bool VerifyPassword(string plainPassword, string passwordHash)
        {
            try
            {
                return _cryptographyService.VerifyPassword(plainPassword, passwordHash);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LoginResponseDto Login(string email, string password)
        {
            var foundUser = _userService.GetUserEntityByEMail(email).GetAwaiter().GetResult();

            if (foundUser == null)
            {
                return GetFailedResult();
            }

            bool isValidPassword = _cryptographyService.VerifyPassword(password, foundUser.PasswordHash);

            return isValidPassword ? GetSuccessfulResult() : GetFailedResult();
        }

        private LoginResponseDto GetSuccessfulResult()
        {
            return new LoginResponseDto
            {
                Expiration = DateTime.UtcNow.AddHours(1),
                Token = "Fake-JWT-Token", //TODO: Implement JWT token generation
                Success = true
            };
        }

        private LoginResponseDto GetFailedResult()
        {
            return new LoginResponseDto
            {
                Success = false,
                ErrorMessage = "Invalid email or password."
            };
        }
    }
}
