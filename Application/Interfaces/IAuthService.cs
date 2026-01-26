using Application.DTO;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        LoginResponseDto Login(string email, string password);
        bool VerifyPassword(string plainPassword, string passwordHash);
    }
}
