using Data.Interfaces;
using Domain.Entities;
using Domain.Enums;
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

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        
        public Task<List<User>> GetAllUsers()
        {
            return _context.Users.ToListAsync();
        }

        public Task<User?> GetUserByEMail(string email)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.EMail == email);
        }

        public Task<List<User>> GetUsersByRoleAsync(UserRole role)
        {
            return _context.Users.Where(u => u.Role == role).ToListAsync();
        }
    }
}
