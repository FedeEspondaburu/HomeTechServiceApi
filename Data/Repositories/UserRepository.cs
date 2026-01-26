using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HomeTechServiceDBContext _context;
        public UserRepository(HomeTechServiceDBContext context)
        {
            _context = context;
        }

        public Task<bool> CheckExistingUserById(int userId)
        {
            return _context.Users.AnyAsync(u => u.Id == userId);
        }

        public async Task<User?> GetUserByEMail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.EMail == email);
        }
    }
}
