namespace Shared.Interfaces
{
    public interface ICryptographyService
    {
        string EncryptPassword(string password);
        bool VerifyPassword(string inputPassword, string stored);
    }
}